using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class NewRecordViewModel
    {
        public RecordViewModel Record { get; set; }
        public EventViewModel Event { get; set; }

        public static NewRecordViewModel Build(OlympicEvent olympicEvent)
        {
            var viewModel = new NewRecordViewModel();

            viewModel.Record = new RecordViewModel();
            viewModel.Event = EventViewModel.Build(olympicEvent);

            return viewModel;
        }

        public Record Map()
        {
            var record = new Record();

            record.Id = Record.RecordId;
            record.OlympicEventId = Event.EventId;
            record.RecordHolder = Record.RecordHolder;
            record.Score = Record.Score.Score;
            record.DateAchieved = DateTime.Now;
            record.Witness1 = Record.Witnesses[0];
            record.Witness2 = Record.Witnesses[1];

            return record;
        }
    }
}