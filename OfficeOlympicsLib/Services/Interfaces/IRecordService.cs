using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOlympicsLib.Services.Interfaces
{
    public interface IRecordService
    {
        Task<IEnumerable<Record>> GetRecentRecordsAsync();
        Task<IEnumerable<Record>> GetRecordsByEventIdAsync(int eventId);
        Task InsertRecordAsync(Record record);
        Task<bool> ScoreBeatsCurrentRecord(int eventId, int score, string recordHolder);
    }
}
