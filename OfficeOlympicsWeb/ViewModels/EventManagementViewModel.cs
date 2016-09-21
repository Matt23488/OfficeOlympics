using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OfficeOlympicsWeb.ViewModels
{
    public class EventManagementViewModel
    {
        public List<EventViewModel> EventList { get; set; }
        public SelectList EventTypeSelectList { get; set; }

        public static EventManagementViewModel Build(IEnumerable<OlympicEvent> events, IEnumerable<EventType> eventTypes)
        {
            var viewModel = new EventManagementViewModel();

            viewModel.EventList = events.Select(obj => EventViewModel.Build(obj)).ToList();
            viewModel.EventTypeSelectList = new SelectList(eventTypes, nameof(EventType.Id), nameof(EventType.Description));

            return viewModel;
        }
    }
}