using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using OfficeOlympicsWeb.ViewModels;
using System.Threading.Tasks;
using OfficeOlympicsLib.Services.Interfaces;
using OfficeOlympicsLib.Models.Constants;
using OfficeOlympicsWeb.Helpers;

namespace OfficeOlympicsWeb.Hubs
{
    public class RecordHub : Hub
    {
        private IRecordService _recordService;

        public RecordHub(IRecordService recordService)
        {
            _recordService = recordService;
        }

        public async Task RecordBroken(NewRecordViewModel newRecord)
        {
            if (!await _recordService.ScoreBeatsCurrentRecord(newRecord.Event.EventId, newRecord.Record.Score.Score, newRecord.Record.Competitor.CompetitorId)) return;

            string scoreString = string.Empty;

            switch (newRecord.Record.Score.EventType)
            {
                case EventType.Timed:
                    scoreString = new TimeSpan(0, 0, newRecord.Record.Score.Score).ToString();
                    break;
                case EventType.RepCount:
                    scoreString = newRecord.Record.Score.Score.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newRecord.Record.Score.EventType));
            }

            string message = $"The record for {newRecord.Event.EventName} has been broken by {newRecord.Record.Competitor.FullName} with a new score of {scoreString}!";

            Clients.Others.displayMessage(message, "success");
        }
    }
}