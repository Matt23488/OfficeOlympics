using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class RecordListViewModel
    {
        public List<RecordViewModel> Records { get; set; }
        public EventViewModel Event { get; set; }

        public static RecordListViewModel Build(IEnumerable<Record> records, OlympicEvent olympicEvent)
        {
            var viewModel = new RecordListViewModel();

            viewModel.Records = RecordViewModel.BuildList(records);
            viewModel.Event = EventViewModel.Build(olympicEvent);

            return viewModel;
        }

        public static List<RecordListViewModel> BuildList(IEnumerable<OlympicEvent> olympicEvents)
        {
            var viewModelList = new List<RecordListViewModel>();

            foreach (var olympicEvent in olympicEvents)
            {
                var relevantRecords = (from record in olympicEvent.Records
                                      orderby record.Score descending
                                      group record by record.CompetitorId into groupedRecords
                                      select groupedRecords.First() into record
                                      select record).Take(3);

                viewModelList.Add(Build(relevantRecords, olympicEvent));
            }

            return viewModelList;
        }
    }
}