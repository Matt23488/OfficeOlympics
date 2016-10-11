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
        void InsertOlympicEvent(OlympicEvent olympicEvent);
        void UpdateOlympicEvent(OlympicEvent olympicEvent);
        void DeleteOlympicEvent(OlympicEvent olympicEvent);
        OlympicEvent GetOlympicEventById(int olympicEventId);
        IEnumerable<OlympicEvent> GetOlympicEvents(bool includeDeleted);
        IEnumerable<OlympicEvent> GetRecentlyAddedOlympicEvents();
        IEnumerable<OlympicEvent> GetRecordBoard();
        OlympicEvent GetRecordBoardEvent(int eventId);
        bool NameIsUnique(OlympicEvent olympicEvent);
    }
}
