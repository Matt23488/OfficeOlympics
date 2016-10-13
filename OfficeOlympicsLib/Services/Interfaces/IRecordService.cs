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
        IEnumerable<Record> GetRecentRecords();
        IEnumerable<Record> GetRecordsByEventId(int eventId, bool onlyBestForCompetitors);
        void InsertRecord(Record record);
        int? TopThreePositionOfNewScore(int eventId, int score, int competitorId);
    }
}
