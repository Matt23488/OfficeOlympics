using OfficeOlympicsLib.Models;
using System.Data.Entity;
using System.Linq;

namespace OfficeOlympicsLib.Extensions
{
    internal static class DatabaseExtensions
    {
        public static IQueryable<Record> FullRecords(this OfficeOlympicsDbEntities context)
        {
            return context.Records
                    .Include(obj => obj.OlympicEvent.EventType)
                    .Include(obj => obj.Competitor)
                    .Include(obj => obj.Witnesses.Select(wit => wit.Competitor));
        }

        public static IQueryable<OlympicEvent> FullOlympicEvents(this OfficeOlympicsDbEntities context)
        {
            return context.OlympicEvents
                    .Include(obj => obj.EventType);
        }
    }
}
