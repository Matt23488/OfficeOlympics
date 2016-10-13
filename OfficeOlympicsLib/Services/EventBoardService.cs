using OfficeOlympicsLib.Extensions;
using OfficeOlympicsLib.Models;
using OfficeOlympicsLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Services
{
    public class EventBoardService : IEventBoardService
    {
        public IEnumerable<OlympicEvent> GetRecordBoard()
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                return context.FullOlympicEvents().Where(obj => obj.IsActive).ToList();
            }
        }

        public OlympicEvent GetRecordBoardEvent(int eventId)
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                return context.FullOlympicEvents().Single(obj => obj.Id == eventId);
            }
        }
    }
}
