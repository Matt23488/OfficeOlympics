using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OfficeOlympicsWeb.ViewModels
{
    public class EditEventViewModel
    {
        public EventViewModel Event { get; set; }
        public SelectList EventTypeSelectList { get; set; }

        public static EditEventViewModel Build(OlympicEvent olympicEvent, IEnumerable<EventType> eventTypes)
        {
            var viewModel = new EditEventViewModel();

            viewModel.Event = EventViewModel.Build(olympicEvent);
            viewModel.EventTypeSelectList = new SelectList(eventTypes, nameof(EventType.Id), nameof(EventType.Description));

            return viewModel;
        }

        public OlympicEvent Map()
        {
            return Event.Map();
        }
    }
}