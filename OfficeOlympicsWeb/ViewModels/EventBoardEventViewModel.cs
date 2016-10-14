using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class EventBoardEventViewModel
    {
        public int EventId { get; set; }
        public int EventTypeId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public string IconFileName { get; set; }
        public List<EventBoardRecordViewModel> Records { get; set; }

        public static EventBoardEventViewModel Build(OlympicEvent olympicEvent)
        {
            var viewModel = new EventBoardEventViewModel();

            viewModel.EventId = olympicEvent.Id;
            viewModel.EventTypeId = olympicEvent.EventTypeId;
            viewModel.EventName = olympicEvent.EventName;
            viewModel.Description = olympicEvent.Description;
            viewModel.Specification = olympicEvent.Specification;
            viewModel.IconFileName = olympicEvent.IconFileName;
            viewModel.Records = EventBoardRecordViewModel.BuildList(olympicEvent.Records);

            return viewModel;
        }

        public static List<EventBoardEventViewModel> BuildList(IEnumerable<OlympicEvent> olympicEvents)
        {
            var viewModelList = new List<EventBoardEventViewModel>();

            foreach (var olympicEvent in olympicEvents)
            {
                viewModelList.Add(Build(olympicEvent));
            }

            return viewModelList;
        }
    }
}