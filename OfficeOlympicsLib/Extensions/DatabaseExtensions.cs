using OfficeOlympicsLib.Models;
using System.Data.Entity;
using System.Linq;

namespace OfficeOlympicsLib.Extensions
{
    internal static class DatabaseExtensions
    {
        public static ParallelQuery<Record> FullRecords(this OfficeOlympicsDbEntities context)
        {
            return context.Records
                    .Include(obj => obj.OlympicEvent)
                    .Include(obj => obj.Competitor)
                    .Include(obj => obj.Witnesses.Select(wit => wit.Competitor))
                    .AsParallel();
        }
    }
}
