﻿using System;
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
    public class OlympicsHub : Hub
    {
        private IRecordService _recordService;

        public OlympicsHub(IRecordService recordService)
        {
            _recordService = recordService;
        }

        // TODO: Need to do something a bit different here. Sometimes the refreshX() methods are called on the clients before the records are saved I'm guessing?
        public async Task RecordBroken(NewRecordViewModel newRecord)
        {
            if (!await _recordService.ScoreBeatsCurrentRecord(newRecord.Event.EventId, newRecord.Record.Score.Score.Value, newRecord.Record.Competitor.CompetitorId)) return;

            string scoreString = string.Empty;

            switch (newRecord.Record.Score.EventType)
            {
                case EventType.Timed:
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
            Clients.Others.refreshRecords();
        }

        public async Task NewEvent(string eventName)
        {
            Clients.Others.displayMessage($"Everyone be sure to try out the new {eventName} event!", "info");

            await Task.Delay(2000);
            Clients.Others.refreshEvents();
        }

        //public async Task EditEvent()
        //{

        //}

        public async Task NewCompetitor(string competitorName)
        {
            Clients.Others.displayMessage($"Everyone welcome {competitorName} into the fray!", "info");

            await Task.Delay(2000);
            Clients.Others.refreshCompetitors();
        }
    }
}