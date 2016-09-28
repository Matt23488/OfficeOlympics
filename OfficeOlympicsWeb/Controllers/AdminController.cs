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
        private ICompetitorService _competitorService;
        private IErrorLogger _errorLogger;

        public AdminController(IOlympicEventService eventService, IEventTypeService eventTypeService, IErrorLogger errorLogger, ICompetitorService competitorService)
        {
            _eventService = eventService;
            _eventTypeService = eventTypeService;
            _competitorService = competitorService;
            _errorLogger = errorLogger;
        }

        #region Olympic Events
        [HttpGet]
        public async Task<ActionResult> EventManagement()
        {
            var events = await _eventService.GetOlympicEventsAsync(includeDeleted: true);
            var viewModel = EventViewModel.BuildList(events);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> AddEvent()
        {
            var eventTypes = await _eventTypeService.GetEventTypesAsync();
            var viewModel = EditEventViewModel.Build(eventTypes);

            ViewBag.EditType = "Add";

            return View("EditEvent", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddEvent(EditEventViewModel viewModel)
        {
            var olympicEvent = viewModel.Map();
            await _eventService.InsertOlympicEventAsync(olympicEvent);

            return RedirectToAction(nameof(EventManagement));
        }

        [HttpGet]
        public async Task<ActionResult> EditEvent(int olympicEventId)
        {
            var olympicEvent = await _eventService.GetOlympicEventByIdAsync(olympicEventId);
            var eventTypes = await _eventTypeService.GetEventTypesAsync();
            var viewModel = EditEventViewModel.Build(olympicEvent, eventTypes);

            ViewBag.EditType = "Edit";

            return View(viewModel);
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
        #endregion

        #region Competitors
        [HttpGet]
        public async Task<ActionResult> CompetitorManagement()
        {
            var competitors = await _competitorService.GetCompetitorsAsync(includeDeleted: true);
            var viewModel = CompetitorViewModel.BuildList(competitors);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> AddCompetitor()
        {
            var viewModel = new CompetitorViewModel();

            ViewBag.EditType = "Add";

            return View("EditCompetitor", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddCompetitor(CompetitorViewModel viewModel)
        {
            var competitor = viewModel.Map();
            await _competitorService.InsertCompetitorAsync(competitor);

            return RedirectToAction(nameof(CompetitorManagement));
        }

        [HttpGet]
        public async Task<ActionResult> EditCompetitor(int competitorId)
        {
            var competitor = await _competitorService.GetCompetitorByIdAsync(competitorId);
            var viewModel = CompetitorViewModel.Build(competitor);

            ViewBag.EditType = "Edit";

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditCompetitor(CompetitorViewModel viewModel, string submitButton)
        {
            var competitor = viewModel.Map();

            switch (submitButton)
            {
                case "Save":
                    await _competitorService.UpdateCompetitorAsync(competitor);
                    break;
                case "Delete":
                    await _competitorService.DeleteCompetitorAsync(competitor);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(submitButton));
            }

            return RedirectToAction(nameof(CompetitorManagement));
        }
        #endregion

        [HttpGet]
        public async Task<ActionResult> ErrorLog(int pageNumber)
        {
            var errorLog = await _errorLogger.GetErrorLogPageAsync(pageNumber);

            return View(errorLog);
        }
    }
}