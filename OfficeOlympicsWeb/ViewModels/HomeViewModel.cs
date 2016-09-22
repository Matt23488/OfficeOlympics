using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class HomeViewModel
    {
        [DisplayName("New Events")]
        public List<EventViewModel> NewEvents { get; set; }

        [DisplayName("New Records")]
        public List<RecordViewModel> NewRecords { get; set; }

        public static HomeViewModel Build(IEnumerable<OlympicEvent> newEvents, IEnumerable<Record> newRecords)
        {
            var viewModel = new HomeViewModel();

            viewModel.NewEvents = EventViewModel.BuildList(newEvents);
            viewModel.NewRecords = RecordViewModel.BuildList(newRecords);

            return viewModel;
        }
    }
}