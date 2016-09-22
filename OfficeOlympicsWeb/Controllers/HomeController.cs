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
    }
}