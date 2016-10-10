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
using OfficeOlympicsWeb.Extensions;

namespace OfficeOlympicsWeb.Hubs
{
    public class OlympicsHub : Hub
    {
        private IRecordService _recordService;

        public OlympicsHub(IRecordService recordService)
        {
            _recordService = recordService;
        }

        public override Task OnConnected()
        {
            var routeValues = RouteHelper.GetRouteDataFromUrl(Context.Headers["Referer"]);
            string group = $"{routeValues["controller"]}/{routeValues["action"]}";
            return Groups.Add(Context.ConnectionId, group);
        }

        public async Task RecordBroken(NewRecordViewModel newRecord)
        {
            if (!_recordService.ScoreBeatsCurrentRecord(newRecord.Event.EventId, newRecord.Record.Score.Score.Value, newRecord.Record.Competitor.CompetitorId)) return;

            string scoreString = string.Empty;

            switch (newRecord.Record.Score.EventType)
            {
                case EventType.TimedHold:
                    scoreString = new TimeSpan(0, 0, newRecord.Record.Score.Score.Value).ToString();
                    break;
                case EventType.RepCount:
                    scoreString = newRecord.Record.Score.Score.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newRecord.Record.Score.EventType));
            }

            string message = $"The record for {newRecord.Event.EventName} has been broken by {newRecord.Record.Competitor.FullName} with a new score of {scoreString}!";

            Clients.Others.displayMessage(message, "success");

            await Task.Delay(2000);
            Clients.Group("Home/About").refreshRecords();
        }

        public async Task NewEvent(string eventName)
        {
            Clients.Others.displayMessage($"Everyone be sure to try out the new {eventName} event!", "info");

            await Task.Delay(2000);
            Clients.Group("Home/About").refreshEvents();
        }

        public async Task EditEvent(string eventName)
        {
            Clients.Others.displayMessage($"The {eventName} event has been updated!", "info");

            await Task.Delay(2000);
            Clients.Group("Home/About").refreshEvents();
            Clients.Group("Home/About").refreshRecords();
        }

        public async Task DeleteEvent(string eventName)
        {
            Clients.Others.displayMessage($"The {eventName} event has been removed.", "warning");

            await Task.Delay(2000);
            Clients.Group("Home/About").refreshEvents();
            Clients.Group("Home/About").refreshRecords();
        }

        public async Task NewCompetitor(string competitorName)
        {
            Clients.Others.displayMessage($"Everyone welcome {competitorName.AsProperNoun()} into the fray!", "info");

            await Task.Delay(2000);
            Clients.Group("Home/About").refreshCompetitors();
        }

        public async Task EditCompetitor(string competitorName)
        {
            Clients.Others.displayMessage($"{competitorName} was updated in some way. Probably his/her name.", "info");

            await Task.Delay(2000);
            Clients.Group("Home/About").refreshCompetitors();
            Clients.Group("Home/About").refreshRecords();
        }

        public async Task DeleteCompetitor(string competitorName)
        {
            Clients.Others.displayMessage($"{competitorName} has left the fray. Quitter!", "warning");

            await Task.Delay(2000);
            Clients.Group("Home/About").refreshCompetitors();
            Clients.Group("Home/About").refreshRecords();
        }
    }
}