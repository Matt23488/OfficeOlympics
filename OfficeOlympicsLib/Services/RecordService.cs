using OfficeOlympicsLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOlympicsLib.Models;

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
    }
}
