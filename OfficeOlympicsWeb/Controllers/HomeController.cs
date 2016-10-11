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
        private ICompetitorService _competitorService;
        private IQuoteService _quoteService;

        public HomeController(IOlympicEventService eventService, IRecordService recordService, ICompetitorService competitorService, IQuoteService quoteService)
        {
            _eventService = eventService;
            _recordService = recordService;
            _competitorService = competitorService;
            _quoteService = quoteService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var olympicEvents = _eventService.GetRecordBoard();
            var viewModel = RecordBoardViewModel.Build(olympicEvents);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult IndexPartial()
        {
            var olympicEvents = _eventService.GetRecordBoard();
            var viewModel = RecordBoardViewModel.Build(olympicEvents);

            return PartialView("Index", viewModel);
        }

        [HttpGet]
        public ActionResult About()
        {
            var recentEvents = _eventService.GetRecentlyAddedOlympicEvents();
            var recentRecords = _recordService.GetRecentRecords();
            var recentCompetitors = _competitorService.GetRecentlyAddedCompetitors();
            var randomQuote = _quoteService.GetRandomQuote();
            var viewModel = HomeViewModel.Build(recentEvents, recentRecords, recentCompetitors, randomQuote);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Records(int? olympicEventId)
        {
            if (!olympicEventId.HasValue)
            {
                return ChooseAnEvent();
            }

            var olympicEvent = _eventService.GetOlympicEventById(olympicEventId.Value);
            var records = _recordService.GetRecordsByEventId(olympicEventId.Value, onlyBestForCompetitors: true);
            var viewModel = RecordListViewModel.Build(records, olympicEvent);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult NewRecord(int olympicEventId)
        {
            var olympicEvent = _eventService.GetOlympicEventById(olympicEventId);
            var competitors = _competitorService.GetCompetitors(includeDeleted: false);
            var viewModel = NewRecordViewModel.Build(olympicEvent, competitors);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult NewRecord(NewRecordViewModel viewModel)
        {
            var record = viewModel.Map();
            _recordService.InsertRecord(record);

            return RedirectToAction(nameof(Records), new { olympicEventId = viewModel.Event.EventId });
        }

        [HttpGet]
        public ActionResult RecentRecords()
        {
            var recentRecords = _recordService.GetRecentRecords();
            var viewModel = RecordViewModel.BuildList(recentRecords);

            return PartialView("RecordListPartial", viewModel);
        }

        [HttpGet]
        public ActionResult RecentEvents()
        {
            var recentEvents = _eventService.GetRecentlyAddedOlympicEvents();
            var viewModel = EventViewModel.BuildList(recentEvents);

            return PartialView("EventListPartial", viewModel);
        }

        [HttpGet]
        public ActionResult RecentCompetitors()
        {
            var recentCompetitors = _competitorService.GetRecentlyAddedCompetitors();
            var viewModel = CompetitorViewModel.BuildList(recentCompetitors);

            return PartialView("CompetitorListPartial", viewModel);
        }

        [HttpGet]
        public ActionResult TopThree(int eventId)
        {
            var olympicEvent = _eventService.GetRecordBoardEvent(eventId);
            var relevantRecords = (from record in olympicEvent.Records
                                   orderby record.Score descending
                                   group record by record.CompetitorId into groupedRecords
                                   select groupedRecords.First() into record
                                   select record).Take(3);
            var viewModel = RecordListViewModel.Build(relevantRecords, olympicEvent);

            return PartialView("TopThreePartial", viewModel);
        }

        [NonAction]
        public ActionResult ChooseAnEvent()
        {
            var events = _eventService.GetOlympicEvents(includeDeleted: false);
            var viewModelList = EventViewModel.BuildList(events);

            return View("EventSelection", viewModelList);
        }
    }
}