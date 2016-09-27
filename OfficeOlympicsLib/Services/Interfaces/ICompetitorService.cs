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
        Task InsertCompetitorAsync(Competitor competitor);
        Task UpdateCompetitorAsync(Competitor competitor);
        Task DeleteCompetitorAsync(Competitor competitor);
        Task<Competitor> GetCompetitorByIdAsync(int competitorId);
        Task<IEnumerable<Competitor>> GetCompetitorsAsync();
        Task<IEnumerable<Competitor>> GetRecentlyAddedCompetitorsAsync();
    }
}
