using OfficeOlympicsLib.Models;
using OfficeOlympicsLib.Services.Interfaces;
using OfficeOlympicsWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OfficeOlympicsWeb.Controllers
{
    public class AdminController : Controller
    {
        private IOlympicEventService _eventService;
        private IEventTypeService _eventTypeService;

        public AdminController(IOlympicEventService eventService, IEventTypeService eventTypeService)
        {
            _eventService = eventService;
            _eventTypeService = eventTypeService;
        }

        [HttpGet]
        public async Task<ActionResult> EventManagement()
        {
            var events = await _eventService.GetOlympicEventsAsync();
            var eventTypes = await _eventTypeService.GetEventTypesAsync();
            var viewModel = EventManagementViewModel.Build(events, eventTypes);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddEvent(OlympicEvent olympicEvent)
        {
            await _eventService.InsertOlympicEventAsync(olympicEvent);

            return RedirectToAction(nameof(EventManagement));
        }

        [HttpGet]
        public async Task<ActionResult> EditEvent(int olympicEventId)
        {
            var olympicEvent = await _eventService.GetOlympicEventByIdAsync(olympicEventId);
            var eventTypes = await _eventTypeService.GetEventTypesAsync();
            var viewModel = EditEventViewModel.Build(olympicEvent, eventTypes);

            return PartialView("EditEventPartial", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditEvent(EditEventViewModel viewModel, string submitButton)
        {
            var olympicEvent = viewModel.Map();

            switch (submitButton)
            {
                case "Save":
                    await _eventService.UpdateOlympicEventAsync(olympicEvent);
                    break;
                case "Delete":
                    await _eventService.DeleteOlympicEventAsync(olympicEvent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(submitButton));
            }

            return RedirectToAction(nameof(EventManagement));
        }
    }
}