using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class EventBoardViewModel
    {
        public List<EventBoardEventViewModel> Events { get; set; }

        public static EventBoardViewModel Build(IEnumerable<OlympicEvent> olympicEvents)
        {
            var viewModel = new EventBoardViewModel();
            
            viewModel.Events = EventBoardEventViewModel.BuildList(olympicEvents);

            return viewModel;
        }
    }
}