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
        public IEnumerable<Record> GetRecentRecords()
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                return (from record in context.FullRecords().AsParallel()
                        group record by record.OlympicEventId into groupedRecords
                        select
                            (from groupedRecord in groupedRecords
                                orderby groupedRecord.Score descending
                                select groupedRecord).FirstOrDefault() into bestScore
                        where bestScore.Competitor.IsActive && bestScore.OlympicEvent.IsActive
                        orderby bestScore.DateAchieved descending
                        select bestScore).Take(5).ToList();
            }
        }

        public IEnumerable<Record> GetRecordsByEventId(int eventId, bool onlyBestForCompetitors)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                IEnumerable<Record> records = (from record in context.FullRecords()
                                               where record.OlympicEventId == eventId
                                                   && record.OlympicEvent.IsActive
                                                   && record.Competitor.IsActive
                                               orderby record.Score descending,
                                                       record.DateAchieved
                                               select record).ToList();

                if (onlyBestForCompetitors)
                {
                    records = records.UniqueConstraint(obj => obj.CompetitorId);
                }

                return records;
            }
        }

        public void InsertRecord(Record record)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                context.Records.Add(record);

                context.SaveChanges();
            }
        }

        public int? TopThreePositionOfNewScore(int eventId, int score, int competitorId)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var topThreeRecords = (from r in context.Records
                                       where r.OlympicEventId == eventId
                                         && r.OlympicEvent.IsActive
                                         && r.Competitor.IsActive
                                       orderby r.Score descending
                                       select new
                                       {
                                           CompetitorId = r.CompetitorId,
                                           Score = r.Score
                                       }).UniqueConstraint(r => r.CompetitorId).Take(3);

                int? scorePosition = topThreeRecords.FirstIndexWhere(r => r.CompetitorId == competitorId && r.Score == score) + 1;
                int? scoreFuturePosition = topThreeRecords.FirstIndexWhere(r => score > r.Score) + 1;

                return scorePosition ?? scoreFuturePosition;
            }
        }
    }
}
