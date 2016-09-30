using OfficeOlympicsLib.Models;
using OfficeOlympicsWeb.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class EventViewModel
    {
        public int EventId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string EventName { get; set; }

        [Required]
        [DisplayName("Event Type")]
        public int EventTypeId { get; set; }

        [DisplayName("Event Type")]
        public string EventType { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Specification")]
        public string Specification { get; set; }

        public DateTime DateAdded { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        public string IconFileName { get; set; }

        public EventViewModel()
        {
            EventId = 0;
            EventName = string.Empty;
            EventType = string.Empty;
            EventTypeId = 0;
            Description = string.Empty;
            Specification = string.Empty;
            DateAdded = DateTime.MinValue;
            IsActive = true;
            IconFileName = string.Empty;
        }

        public static EventViewModel Build(OlympicEvent olympicEvent)
        {
            var viewModel = new EventViewModel();

            viewModel.EventId = olympicEvent.Id;
            viewModel.EventName = olympicEvent.EventName;
            viewModel.EventType = olympicEvent.EventType.Description;
            viewModel.EventTypeId = olympicEvent.EventType.Id;
            viewModel.Description = olympicEvent.Description;
            viewModel.Specification = olympicEvent.Specification;
            viewModel.DateAdded = olympicEvent.DateAdded;
            viewModel.IsActive = olympicEvent.IsActive;
            viewModel.IconFileName = olympicEvent.IconFileName;

            return viewModel;
        }

        public static List<EventViewModel> BuildList(IEnumerable<OlympicEvent> olympicEvents)
        {
            var viewModelList = new List<EventViewModel>();

            foreach (var olympicEvent in olympicEvents)
            {
                viewModelList.Add(Build(olympicEvent));
            }

            return viewModelList;
        }

        public OlympicEvent Map()
        {
            var olympicEvent = new OlympicEvent();

            olympicEvent.Id = EventId;
            olympicEvent.EventName = EventName.AsProperNoun();
            olympicEvent.EventTypeId = EventTypeId;
            olympicEvent.Description = Description?.Trim() ?? string.Empty;
            olympicEvent.Specification = Specification?.Trim() ?? string.Empty;
            olympicEvent.DateAdded = EventId == 0 ? DateTime.Now : DateAdded;
            olympicEvent.IsActive = IsActive;

            return olympicEvent;
        }
    }
}