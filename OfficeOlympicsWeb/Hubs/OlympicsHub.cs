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

        public void RecordBroken(NewRecordViewModel newRecord)
        {
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

            int? topThreePosition = _recordService.TopThreePositionOfNewScore(newRecord.Event.EventId, newRecord.Record.Score.Score.Value, newRecord.Record.Competitor.CompetitorId);
            if (topThreePosition.HasValue)
            {
                string placeValue = string.Empty;
                switch (topThreePosition.Value)
                {
                    case 1:
                        placeValue = "first";
                        break;
                    case 2:
                        placeValue = "second";
                        break;
                    case 3:
                        placeValue = "third";
                        break;
                }

                string message = $"{newRecord.Record.Competitor.FullName.AsProperNoun()} just got {placeValue} place in the {newRecord.Event.EventName} event!";
                Clients.Others.displayMessage(message, "success");

                if (topThreePosition == 1)
                {
                    Clients.Group("Home/About").refreshRecords();
                }

                Clients.Group("Home/Index").refreshRecords(newRecord.Event.EventId);
            }
        }

        public async Task NewEvent(string eventName)
        {
            string properEventName = eventName.AsProperNoun();

            Clients.Others.displayMessage($"Everyone be sure to try out the new {properEventName} event!", "info");

            await Task.Delay(2000);
            Clients.Group("Home/About").refreshEvents();
            Clients.Group("Home/Index").refreshBoard();
        }

        public async Task EditEvent(EventViewModel olympicEvent)
        {
            string properEventName = olympicEvent.EventName.AsProperNoun();

            Clients.Others.displayMessage($"The {properEventName} event has been updated!", "info");

            await Task.Delay(2000);
            Clients.Group("Home/About").refreshEvents();
            Clients.Group("Home/About").refreshRecords();
            Clients.Group("Home/Index").refreshRecords(olympicEvent.EventId);
        }

        public async Task DeleteEvent(string eventName)
        {
            string properEventName = eventName.AsProperNoun();

            Clients.Others.displayMessage($"The {properEventName} event has been removed.", "warning");

            await Task.Delay(2000);
            Clients.Group("Home/About").refreshEvents();
            Clients.Group("Home/About").refreshRecords();
            Clients.Group("Home/Index").refreshBoard();
        }

        public async Task NewCompetitor(string competitorName)
        {
            string properCompetitorName = competitorName.AsProperNoun();

            Clients.Others.displayMessage($"Everyone welcome {properCompetitorName} into the fray!", "info");

            await Task.Delay(2000);
            Clients.Group("Home/About").refreshCompetitors();
            Clients.Group("Home/Index").refreshBoard();
        }

        public async Task EditCompetitor(string competitorName)
        {
            string properCompetitorName = competitorName.AsProperNoun();

            Clients.Others.displayMessage($"{properCompetitorName} was updated in some way. Probably his/her name.", "info");

            await Task.Delay(2000);
            Clients.Group("Home/About").refreshCompetitors();
            Clients.Group("Home/About").refreshRecords();
            Clients.Group("Home/Index").refreshBoard();
        }

        public async Task DeleteCompetitor(string competitorName)
        {
            string properCompetitorName = competitorName.AsProperNoun();

            Clients.Others.displayMessage($"{properCompetitorName} has left the fray. Quitter!", "warning");

            await Task.Delay(2000);
            Clients.Group("Home/About").refreshCompetitors();
            Clients.Group("Home/About").refreshRecords();
            Clients.Group("Home/Index").refreshBoard();
        }
    }
}