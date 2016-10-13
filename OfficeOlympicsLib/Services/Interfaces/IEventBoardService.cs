using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Services.Interfaces
{
    public interface IEventBoardService
    {
        IEnumerable<OlympicEvent> GetRecordBoard();
        OlympicEvent GetRecordBoardEvent(int eventId);
    }
}
