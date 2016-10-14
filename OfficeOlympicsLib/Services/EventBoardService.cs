using OfficeOlympicsLib.Extensions;
using OfficeOlympicsLib.Models;
using OfficeOlympicsLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Services
{
    public class EventBoardService : IEventBoardService
    {
        public IEnumerable<OlympicEvent> GetRecordBoard()
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var olympicEvents = context.OlympicEvents.Where(obj => obj.IsActive).ToList();

                foreach (var olympicEvent in olympicEvents)
                {
                    ExplicitLoadOlympicEvent(context, olympicEvent);
                }

                return olympicEvents.ToList();
            }
        }

        public OlympicEvent GetRecordBoardEvent(int eventId)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var olympicEvent = context.OlympicEvents.Single(obj => obj.Id == eventId);

                ExplicitLoadOlympicEvent(context, olympicEvent);

                return olympicEvent;
            }
        }

        private void ExplicitLoadOlympicEvent(OfficeOlympicsDbEntities context, OlympicEvent olympicEvent)
        {
            (from record in context.Entry(olympicEvent).Collection(e => e.Records).Query()
             where record.Competitor.IsActive
             group record by record.CompetitorId into groupedRecords
             select groupedRecords.OrderByDescending(record => record.Score).FirstOrDefault() into record
             orderby record.Score descending
             select record).Take(3).Load();

            context.Entry(olympicEvent).Reference(obj => obj.EventType).Load();

            foreach (var record in olympicEvent.Records)
            {
                context.Entry(record).Reference(obj => obj.Competitor).Load();
            }
        }
    }
}
