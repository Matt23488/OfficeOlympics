using OfficeOlympicsLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOlympicsLib.Models;
using OfficeOlympicsLib.Extensions;
using System.IO;
using System.Configuration;

namespace OfficeOlympicsLib.Services
{
    public class OlympicEventService : IOlympicEventService
    {
        private readonly string _iconPath;

        public OlympicEventService()
        {
            _iconPath = ConfigurationManager.AppSettings["IconSaveLocation"];
        }

        public void InsertOlympicEvent(OlympicEvent olympicEvent)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                Guid iconFileNameGuid = Guid.NewGuid();
                olympicEvent.IconFileName = $"{iconFileNameGuid}{Path.GetExtension(olympicEvent.Icon?.UploadedFileName ?? "default.png")}";

                if (olympicEvent.Icon != null)
                {
                    File.WriteAllBytes(Path.Combine(_iconPath, olympicEvent.IconFileName), olympicEvent.Icon.Bytes);
                }

                context.OlympicEvents.Add(olympicEvent);

                context.SaveChanges();
            }
        }

        public void UpdateOlympicEvent(OlympicEvent olympicEvent)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var existingEvent = context.OlympicEvents.SingleOrDefault(obj => obj.Id == olympicEvent.Id);

                if (existingEvent == null)
                {
                    throw new InvalidOperationException($"Olympic Event '{olympicEvent.EventName}' doesn't exist.");
                }
                
                if (olympicEvent.Icon != null)
                {
                    Func<string> generateIconPath = () => Path.Combine(_iconPath, existingEvent.IconFileName);
                    File.Delete(generateIconPath());
                    existingEvent.IconFileName = $"{Path.GetFileNameWithoutExtension(existingEvent.IconFileName)}{Path.GetExtension(olympicEvent.Icon.UploadedFileName)}";
                    File.WriteAllBytes(generateIconPath(), olympicEvent.Icon.Bytes);
                }

                existingEvent.EventName = olympicEvent.EventName;
                existingEvent.EventTypeId = olympicEvent.EventTypeId;
                existingEvent.Description = olympicEvent.Description;
                existingEvent.Specification = olympicEvent.Specification;
                existingEvent.IsActive = olympicEvent.IsActive;

                context.SaveChanges();
            }
        }

        public void DeleteOlympicEvent(OlympicEvent olympicEvent)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var existingEvent = context.OlympicEvents.SingleOrDefault(obj => obj.Id == olympicEvent.Id);

                if (existingEvent == null)
                {
                    throw new InvalidOperationException($"Olympic Event '{olympicEvent.EventName}' doesn't exist.");
                }

                existingEvent.IsActive = false;

                context.SaveChanges();
            }
        }

        public OlympicEvent GetOlympicEventById(int olympicEventId)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var olympicEvent = context.FullOlympicEvents().SingleOrDefault(obj => obj.Id == olympicEventId);
                    
                return olympicEvent;
            }
        }

        public IEnumerable<OlympicEvent> GetOlympicEvents(bool includeDeleted)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var olympicEvents = (from ev in context.FullOlympicEvents()
                                     where ev.IsActive || includeDeleted
                                     orderby ev.IsActive descending,
                                             ev.EventTypeId,
                                             ev.EventName
                                     select ev).ToList();

                return olympicEvents;
            }
        }

        public IEnumerable<OlympicEvent> GetRecentlyAddedOlympicEvents()
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var olympicEvents = (from ev in context.FullOlympicEvents()
                                     where ev.IsActive
                                     orderby ev.DateAdded descending
                                     select ev).Take(5).ToList();

                return olympicEvents;
            }
        }
    }
}
