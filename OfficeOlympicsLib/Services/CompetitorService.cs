using OfficeOlympicsLib.Models;
using OfficeOlympicsLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Services
{
    public class CompetitorService : ICompetitorService
    {
        public async Task InsertCompetitorAsync(Competitor competitor)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                context.Competitors.Add(competitor);

                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateCompetitorAsync(Competitor competitor)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var existingCompetitor = context.Competitors.AsParallel().SingleOrDefault(obj => obj.Id == competitor.Id);

                if (existingCompetitor == null)
                {
                    throw new InvalidOperationException($"Competitor '{competitor.FirstName} {competitor.LastName}' doesn't exist.");
                }

                existingCompetitor.FirstName = competitor.FirstName;
                existingCompetitor.LastName = competitor.LastName;
                existingCompetitor.IsActive = competitor.IsActive;

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteCompetitorAsync(Competitor competitor)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var existingCompetitor = context.Competitors.AsParallel().SingleOrDefault(obj => obj.Id == competitor.Id);

                if (existingCompetitor == null)
                {
                    throw new InvalidOperationException($"Competitor '{competitor.FirstName} {competitor.LastName}' doesn't exist.");
                }

                existingCompetitor.IsActive = false;

                await context.SaveChangesAsync();
            }
        }

        public async Task<Competitor> GetCompetitorByIdAsync(int competitorId)
        {
            return await Task.Run(() =>
            {
                using (var context = new OfficeOlympicsDbEntities())
                {
                    return context.Competitors.AsParallel().SingleOrDefault(obj => obj.Id == competitorId);
                }
            });
        }

        public async Task<IEnumerable<Competitor>> GetCompetitorsAsync(bool includeDeleted)
        {
            return await Task.Run(() =>
            {
                using (var context = new OfficeOlympicsDbEntities())
                {
                    return context.Competitors
                    .AsParallel()
                    .Where(obj => obj.IsActive || includeDeleted)
                    .OrderByDescending(obj => obj.IsActive)
                    .ToList();
                }
            });
        }

        public async Task<IEnumerable<Competitor>> GetRecentlyAddedCompetitorsAsync()
        {
            return await Task.Run(() =>
            {
                using (var context = new OfficeOlympicsDbEntities())
                {
                    return (from competitor in context.Competitors.AsParallel()
                            where competitor.IsActive
                            orderby competitor.Id descending
                            select competitor).Take(5).ToList();
                }
            });
        }
    }
}
