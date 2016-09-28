using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OfficeOlympicsWeb.ViewModels
{
    public class EditEventViewModel
    {
        public EventViewModel Event { get; set; }
        public SelectList EventTypeSelectList { get; set; }

        [DisplayName("Icon")]
        public HttpPostedFileBase EventIcon { get; set; }

        public static EditEventViewModel Build(IEnumerable<EventType> eventTypes)
        {
            var viewModel = new EditEventViewModel();

            viewModel.Event = new EventViewModel();
            viewModel.EventTypeSelectList = new SelectList(eventTypes, nameof(EventType.Id), nameof(EventType.Description));

            return viewModel;
        }

        public static EditEventViewModel Build(OlympicEvent olympicEvent, IEnumerable<EventType> eventTypes)
        {
            var viewModel = new EditEventViewModel();

            viewModel.Event = EventViewModel.Build(olympicEvent);
            viewModel.EventTypeSelectList = new SelectList(eventTypes, nameof(EventType.Id), nameof(EventType.Description));

            return viewModel;
        }

        public OlympicEvent Map()
        {
            var olympicEvent = Event.Map();

            using (var memoryStream = new MemoryStream())
            {
                EventIcon.InputStream.CopyTo(memoryStream);
                
                olympicEvent.Icon = new IconFile();
                olympicEvent.Icon.UploadedFileName = EventIcon.FileName;
                olympicEvent.Icon.Bytes = memoryStream.ToArray();
            }

            return olympicEvent;
        }
    }
}