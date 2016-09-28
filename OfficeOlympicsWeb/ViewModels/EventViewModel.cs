﻿using OfficeOlympicsLib.Models;
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

        public EventViewModel()
        {
            EventId = 0;
            EventName = string.Empty;
            EventType = string.Empty;
            Description = string.Empty;
            Specification = string.Empty;
            DateAdded = DateTime.MinValue;
            IsActive = true;
            EventTypeId = 0;
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
            olympicEvent.EventName = EventName.Trim();
            olympicEvent.EventTypeId = EventTypeId;
            olympicEvent.Description = Description?.Trim() ?? string.Empty;
            olympicEvent.Specification = Specification?.Trim() ?? string.Empty;
            olympicEvent.DateAdded = EventId == 0 ? DateTime.Now : DateAdded;
            olympicEvent.IsActive = IsActive;

            return olympicEvent;
        }
    }
}