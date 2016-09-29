using OfficeOlympicsLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOlympicsLib.Models;

namespace OfficeOlympicsLib.Services
{
    public class EventTypeService : IEventTypeService
    {
        public IEnumerable<EventType> GetEventTypes()
        {
            using (var context = new OfficeOlympicsDbEntities())
            {
                return context.EventTypes.ToList();
            }
        }
    }
}
