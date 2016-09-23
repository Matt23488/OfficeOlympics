using Microsoft.AspNet.SignalR;
using OfficeOlympicsLib.Services.Interfaces;
using OfficeOlympicsWeb.Hubs;
using OfficeOlympicsWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OfficeOlympicsWeb.Controllers
{
    public class HomeController : Controller
    {
        private IOlympicEventService _eventService;
        private IRecordService _recordService;

        public HomeController(IOlympicEventService eventService, IRecordService recordService)
        {
            _eventService = eventService;
            _recordService = recordService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var recentEvents = await _eventService.GetRecentlyAddedOlympicEventsAsync();
            var recentRecords = await _recordService.GetRecentRecordsAsync();
            var viewModel = HomeViewModel.Build(recentEvents, recentRecords);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Records(int? olympicEventId)
        {
            if (!olympicEventId.HasValue)
            {
                return await ChooseAnEvent();
            }

            var olympicEvent = await _eventService.GetOlympicEventByIdAsync(olympicEventId.Value);
            var records = await _recordService.GetRecordsByEventIdAsync(olympicEventId.Value);
            var viewModel = RecordListViewModel.Build(records, olympicEvent);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> NewRecord(int olympicEventId)
        {
            var olympicEvent = await _eventService.GetOlympicEventByIdAsync(olympicEventId);
            var viewModel = NewRecordViewModel.Build(olympicEvent);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> NewRecord(NewRecordViewModel viewModel)
        {
            var record = viewModel.Map();
            await _recordService.InsertRecordAsync(record);

            return RedirectToAction(nameof(Records), new { olympicEventId = viewModel.Event.EventId });
        }

        [NonAction]
        public async Task<ActionResult> ChooseAnEvent()
        {
            var events = await _eventService.GetOlympicEventsAsync();
            var viewModelList = EventViewModel.BuildList(events);

            return View("EventSelection", viewModelList);
        }
    }
}