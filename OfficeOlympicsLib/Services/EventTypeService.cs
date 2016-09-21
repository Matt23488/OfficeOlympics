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
        public async Task<IEnumerable<EventType>> GetEventTypesAsync()
        {
            return await Task.Run(() =>
            {
                using (var context = new OfficeOlympicsDbEntities())
                {
                    return context.EventTypes.AsParallel().ToList();
                }
            });
        }
    }
}
