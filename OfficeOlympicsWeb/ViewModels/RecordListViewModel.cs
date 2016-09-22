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
    }
}