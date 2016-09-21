using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class EventViewModel
    {
        public int EventId { get; set; }

        [DisplayName("Name")]
        public string EventName { get; set; }

        [DisplayName("Event Type")]
        public string EventType { get; set; }

        public int EventTypeId { get; set; }

        public static EventViewModel Build(OlympicEvent olympicEvent)
        {
            var viewModel = new EventViewModel();

            viewModel.EventId = olympicEvent.Id;
            viewModel.EventName = olympicEvent.EventName;
            viewModel.EventType = olympicEvent.EventType.Description;
            viewModel.EventTypeId = olympicEvent.EventType.Id;

            return viewModel;
        }

        public OlympicEvent Map()
        {
            var olympicEvent = new OlympicEvent();

            olympicEvent.Id = EventId;
            olympicEvent.EventName = EventName;
            olympicEvent.EventTypeId = EventTypeId;

            return olympicEvent;
        }
    }
}