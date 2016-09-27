using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OfficeOlympicsWeb.ViewModels
{
    public class NewRecordViewModel
    {
        public SelectList Competitors { get; set; }
        public RecordViewModel Record { get; set; }
        public EventViewModel Event { get; set; }

        public static NewRecordViewModel Build(OlympicEvent olympicEvent, IEnumerable<Competitor> competitors)
        {
            var viewModel = new NewRecordViewModel();

            viewModel.Competitors = new SelectList(CompetitorViewModel.BuildList(competitors), nameof(CompetitorViewModel.CompetitorId), nameof(CompetitorViewModel.FullName));
            viewModel.Record = new RecordViewModel();
            viewModel.Event = EventViewModel.Build(olympicEvent);

            return viewModel;
        }

        public Record Map()
        {
            var record = new Record();

            record.Id = Record.RecordId;
            record.OlympicEventId = Event.EventId;
            record.CompetitorId = Record.Competitor.CompetitorId;
            record.Score = Record.Score.Score;
            record.DateAchieved = DateTime.Now;
            record.Witnesses.Add(new Witness
            {
                RecordId = Record.RecordId,
                CompetitorId = Record.Witness1.CompetitorId
            });
            record.Witnesses.Add(new Witness
            {
                RecordId = Record.RecordId,
                CompetitorId = Record.Witness2.CompetitorId
            });

            return record;
        }
    }
}