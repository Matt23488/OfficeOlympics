using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Services.Interfaces
{
    public interface IOlympicEventService
    {
        Task InsertOlympicEventAsync(OlympicEvent olympicEvent);
        Task UpdateOlympicEventAsync(OlympicEvent olympicEvent);
        Task DeleteOlympicEventAsync(OlympicEvent olympicEvent);
        Task<OlympicEvent> GetOlympicEventByIdAsync(int olympicEventId);
        Task<IEnumerable<OlympicEvent>> GetOlympicEventsAsync(bool includeDeleted);
        Task<IEnumerable<OlympicEvent>> GetRecentlyAddedOlympicEventsAsync();
    }
}
