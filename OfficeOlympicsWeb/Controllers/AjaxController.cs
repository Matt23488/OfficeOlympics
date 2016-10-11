using OfficeOlympicsLib.Services.Interfaces;
using OfficeOlympicsWeb.Attributes;
using OfficeOlympicsWeb.Extensions;
using OfficeOlympicsWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OfficeOlympicsWeb.Controllers
{
    public class AjaxController : Controller
    {
        private IOlympicEventService _eventService;

        public AjaxController(IOlympicEventService eventService)
        {
            _eventService = eventService;
        }

        [Ajax]
        [HttpGet]
        public ActionResult UniqueEventName(EventViewModel viewModel)
        {
            var olympicEvent = viewModel.Map();

            return Json(_eventService.NameIsUnique(olympicEvent), JsonRequestBehavior.AllowGet);
        }
    }
}