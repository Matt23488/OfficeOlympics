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
                            orderby bestScore.DateAchieved descending
                            select bestScore).ToList();
                }
            });
        }

        public async Task<IEnumerable<Record>> GetRecordsByEventIdAsync(int eventId)
        {
            return await Task.Run(() =>
            {
                using (var context = new OfficeOlympicsDbEntities())
                {
                    return (from record in context.FullRecords()
                            where record.OlympicEventId == eventId
                            orderby record.Score descending
                            select record).ToList();
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

        // TODO: This might need to change, the recordHolder parameter doesn't fit with the new paradigm
        public async Task<bool> ScoreBeatsCurrentRecord(int eventId, int score, string recordHolder)
        {
            return await Task.Run(() =>
            {
                using (var context = new OfficeOlympicsDbEntities())
                {
                    var bestRecord = (from r in context.Records.AsParallel()
                                      where r.OlympicEventId == eventId
                                      select r).ItemWithMaxOrDefault(r => r.Score);

                    bool samePersonAndScoreAsCurrentRecord = (bestRecord != null) && (bestRecord.Score == score && bestRecord.Competitor.FullName.Equals(recordHolder, StringComparison.CurrentCultureIgnoreCase));
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
