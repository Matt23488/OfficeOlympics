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
        public ActionResult EventManagement()
        {
            var events = _eventService.GetOlympicEvents(includeDeleted: true);
            var viewModel = EventViewModel.BuildList(events);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddEvent()
        {
            var eventTypes = _eventTypeService.GetEventTypes();
            var viewModel = EditEventViewModel.Build(eventTypes);

            ViewBag.EditType = "Add";

            return View("EditEvent", viewModel);
        }

        [HttpPost]
        public ActionResult AddEvent(EditEventViewModel viewModel)
        {
            var olympicEvent = viewModel.Map();
            _eventService.InsertOlympicEvent(olympicEvent);

            return RedirectToAction(nameof(EventManagement));
        }

        [HttpGet]
        public ActionResult EditEvent(int olympicEventId)
        {
            var olympicEvent = _eventService.GetOlympicEventById(olympicEventId);
            var eventTypes = _eventTypeService.GetEventTypes();
            var viewModel = EditEventViewModel.Build(olympicEvent, eventTypes);

            ViewBag.EditType = "Edit";

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditEvent(EditEventViewModel viewModel, string submitButton)
        {
            var olympicEvent = viewModel.Map();

            switch (submitButton)
            {
                case "Save":
                    _eventService.UpdateOlympicEvent(olympicEvent);
                    break;
                case "Delete":
                    _eventService.DeleteOlympicEvent(olympicEvent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(submitButton));
            }

            return RedirectToAction(nameof(EventManagement));
        }
        #endregion

        #region Competitors
        [HttpGet]
        public ActionResult CompetitorManagement()
        {
            var competitors = _competitorService.GetCompetitors(includeDeleted: true);
            var viewModel = CompetitorListViewModel.Build(competitors);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddCompetitor()
        {
            var viewModel = new CompetitorViewModel();

            ViewBag.EditType = "Add";

            return View("EditCompetitor", viewModel);
        }

        [HttpPost]
        public ActionResult AddCompetitor(CompetitorViewModel viewModel)
        {
            var competitor = viewModel.Map();
            _competitorService.InsertCompetitor(competitor);

            return RedirectToAction(nameof(CompetitorManagement));
        }

        [HttpGet]
        public ActionResult EditCompetitor(int competitorId)
        {
            var competitor = _competitorService.GetCompetitorById(competitorId);
            var viewModel = CompetitorViewModel.Build(competitor);

            ViewBag.EditType = "Edit";

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditCompetitor(CompetitorViewModel viewModel, string submitButton)
        {
            var competitor = viewModel.Map();

            switch (submitButton)
            {
                case "Save":
                    _competitorService.UpdateCompetitor(competitor);
                    break;
                case "Delete":
                    _competitorService.DeleteCompetitor(competitor);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(submitButton));
            }

            return RedirectToAction(nameof(CompetitorManagement));
        }
        #endregion

        [HttpGet]
        public ActionResult ErrorLog(int pageNumber)
        {
            var errorLog = _errorLogger.GetErrorLogPage(pageNumber);

            return View(errorLog);
        }
    }
}