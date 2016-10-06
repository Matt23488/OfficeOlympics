using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class RecordBoardViewModel
    {
        public List<RecordListViewModel> EventsWithRecords { get; set; }

        public static RecordBoardViewModel Build(IEnumerable<OlympicEvent> olympicEvents)
        {
            var viewModel = new RecordBoardViewModel();

            viewModel.EventsWithRecords = RecordListViewModel.BuildList(olympicEvents);

            return viewModel;
        }
    }
}