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
        public void InsertCompetitor(Competitor competitor)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                context.Competitors.Add(competitor);

                context.SaveChanges();
            }
        }

        public void UpdateCompetitor(Competitor competitor)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var existingCompetitor = context.Competitors.SingleOrDefault(obj => obj.Id == competitor.Id);

                if (existingCompetitor == null)
                {
                    throw new InvalidOperationException($"Competitor '{competitor.FirstName} {competitor.LastName}' doesn't exist.");
                }

                existingCompetitor.FirstName = competitor.FirstName;
                existingCompetitor.LastName = competitor.LastName;
                existingCompetitor.IsActive = competitor.IsActive;

                context.SaveChanges();
            }
        }

        public void DeleteCompetitor(Competitor competitor)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                var existingCompetitor = context.Competitors.SingleOrDefault(obj => obj.Id == competitor.Id);

                if (existingCompetitor == null)
                {
                    throw new InvalidOperationException($"Competitor '{competitor.FirstName} {competitor.LastName}' doesn't exist.");
                }

                existingCompetitor.IsActive = false;

                context.SaveChanges();
            }
        }

        public Competitor GetCompetitorById(int competitorId)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                return context.Competitors.SingleOrDefault(obj => obj.Id == competitorId);
            }
        }

        public IEnumerable<Competitor> GetCompetitors(bool includeDeleted)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                return (from competitor in context.Competitors
                        where competitor.IsActive || includeDeleted
                        orderby competitor.IsActive descending,
                                competitor.LastName
                        select competitor).ToList();
            }
        }

        public IEnumerable<Competitor> GetRecentlyAddedCompetitors()
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                return (from competitor in context.Competitors
                        where competitor.IsActive
                        orderby competitor.Id descending
                        select competitor).Take(5).ToList();
            }
        }
    }
}
