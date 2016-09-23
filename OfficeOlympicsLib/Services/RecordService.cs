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
                    return (from record in context.Records.Include(obj => obj.OlympicEvent).AsParallel()
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
                    return (from record in context.Records.Include(obj => obj.OlympicEvent).AsParallel()
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

                await context.Entry(record).Reference(obj => obj.OlympicEvent).LoadAsync();
            }
        }

        public async Task<bool> ScoreBeatsCurrentRecord(int eventId, int score)
        {
            return await Task.Run(() =>
            {
                using (var context = new OfficeOlympicsDbEntities())
                {
                    var bestRecord = (from r in context.Records.AsParallel()
                                      where r.OlympicEventId == eventId
                                      select r).ItemWithMaxOrDefault(r => r.Score);

                    return score > (bestRecord?.Score ?? 0);
                }
            });
        }
    }
}
