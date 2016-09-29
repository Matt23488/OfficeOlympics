using OfficeOlympicsLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOlympicsLib.Models;
using OfficeOlympicsLib.Extensions;

namespace OfficeOlympicsLib.Services
{
    public class RecordService : IRecordService
    {
        public async Task<IEnumerable<Record>> GetRecentRecordsAsync()
        {
            return await Task.Run(() =>
            {
                using (var context = new OfficeOlympicsDbEntities())
                {
                    return (from record in context.FullRecords()
                            group record by record.OlympicEventId into groupedRecords
                            select
                                (from groupedRecord in groupedRecords
                                 orderby groupedRecord.Score descending
                                 select groupedRecord).FirstOrDefault() into bestScore
                            where bestScore.Competitor.IsActive && bestScore.OlympicEvent.IsActive
                            orderby bestScore.DateAchieved descending
                            select bestScore).ToList();
                }
            });
        }

        public async Task<IEnumerable<Record>> GetRecordsByEventIdAsync(int eventId, bool onlyBestForCompetitors)
        {
            return await Task.Run(() =>
            {
                using (var context = new OfficeOlympicsDbEntities())
                {
                    IEnumerable<Record> records = (from record in context.FullRecords()
                                                   where record.OlympicEventId == eventId
                                                       && record.OlympicEvent.IsActive
                                                       && record.Competitor.IsActive
                                                   orderby record.Score descending
                                                   select record).ToList();

                    if (onlyBestForCompetitors)
                    {
                        records = records.UniqueConstraint(obj => obj.CompetitorId);
                    }

                    return records;
                }
            });
        }

        public async Task InsertRecordAsync(Record record)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                context.Records.Add(record);

                await context.SaveChangesAsync();
            }
        }
        
        public async Task<bool> ScoreBeatsCurrentRecord(int eventId, int score, int competitorId)
        {
            return await Task.Run(() =>
            {
                using (var context = new OfficeOlympicsDbEntities())
                {
                    var bestRecord = (from r in context.Records
                                      where r.OlympicEventId == eventId
                                        && r.OlympicEvent.IsActive
                                        && r.Competitor.IsActive
                                      select r).ItemWithMaxOrDefault(r => r.Score);

                    bool samePersonAndScoreAsCurrentRecord = (bestRecord != null) && (bestRecord.Score == score && bestRecord.Competitor.Id == competitorId);
                    bool betterScoreThanCurrentRecord = score > (bestRecord?.Score ?? 0);

                    // If samePersonAndScoreAsCurrentRecord is set, it's likely because the new
                    // record has already been saved to the database before we get this call via
                    // SignalR. If that's not the case, somebody entered a new record that ties
                    // the current record and it happens to be the same person, which should
                    // never happen if the software is being used properly.
                    return samePersonAndScoreAsCurrentRecord || betterScoreThanCurrentRecord;
                }
            });
        }
    }
}
