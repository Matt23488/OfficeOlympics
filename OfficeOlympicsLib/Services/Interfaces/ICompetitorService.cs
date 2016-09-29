using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Services.Interfaces
{
    public interface ICompetitorService
    {
        void InsertCompetitor(Competitor competitor);
        void UpdateCompetitor(Competitor competitor);
        void DeleteCompetitor(Competitor competitor);
        Competitor GetCompetitorById(int competitorId);
        IEnumerable<Competitor> GetCompetitors(bool includeDeleted);
        IEnumerable<Competitor> GetRecentlyAddedCompetitors();
    }
}
