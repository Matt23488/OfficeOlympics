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
    public class OlympicEventService : IOlympicEventService
    {
        public async Task InsertOlympicEventAsync(OlympicEvent olympicEvent)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                context.OlympicEvents.Add(olympicEvent);

                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateOlympicEventAsync(OlympicEvent olympicEvent)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var existingEvent = context.OlympicEvents.AsParallel().SingleOrDefault(obj => obj.Id == olympicEvent.Id);

                if (existingEvent == null)
                {
                    throw new InvalidOperationException($"Olympic Event '{olympicEvent.EventName}' doesn't exist.");
                }

                existingEvent.EventName = olympicEvent.EventName;
                existingEvent.EventTypeId = olympicEvent.EventTypeId;
                existingEvent.Description = olympicEvent.Description;
                existingEvent.Specification = olympicEvent.Specification;

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteOlympicEventAsync(OlympicEvent olympicEvent)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var existingEvent = context.OlympicEvents.AsParallel().SingleOrDefault(obj => obj.Id == olympicEvent.Id);

                if (existingEvent == null)
                {
                    throw new InvalidOperationException($"Olympic Event '{olympicEvent.EventName}' doesn't exist.");
                }

                context.OlympicEvents.Remove(existingEvent);

                await context.SaveChangesAsync();
            }
        }

        public async Task<OlympicEvent> GetOlympicEventByIdAsync(int olympicEventId)
        {
            return await Task.Run(() =>
            {
                using (var context = new OfficeOlympicsDbEntities())
                {
                    return context.OlympicEvents
                        .Include(obj => obj.EventType)
                        .AsParallel().SingleOrDefault(obj => obj.Id == olympicEventId);
                }
            });
        }

        public async Task<IEnumerable<OlympicEvent>> GetOlympicEventsAsync()
        {
            return await Task.Run(() =>
            {
                using (var context = new OfficeOlympicsDbEntities())
                {
                    return context.OlympicEvents
                        .Include(obj => obj.EventType)
                        .AsParallel().ToList();
                }
            });
        }

        public async Task<IEnumerable<OlympicEvent>> GetRecentlyAddedOlympicEventsAsync()
        {
            return await Task.Run(() =>
            {
                using (var context = new OfficeOlympicsDbEntities())
                {
                    return (from ev in context.OlympicEvents.Include(obj => obj.EventType).AsParallel()
                            orderby ev.DateAdded descending
                            select ev).Take(5).ToList();
                }
            });
        }
    }
}
