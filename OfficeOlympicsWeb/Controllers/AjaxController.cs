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
        private IRecordService _recordService;

        public AjaxController(IOlympicEventService eventService, IRecordService recordService)
        {
            _eventService = eventService;
            _recordService = recordService;
        }

        [Ajax]
        [HttpGet]
        public ActionResult UniqueEventName(EventViewModel viewModel)
        {
            var olympicEvent = viewModel.Map();

            return Json(_eventService.NameIsUnique(olympicEvent), JsonRequestBehavior.AllowGet);
        }

        [Ajax]
        [HttpPost]
        public ActionResult NewRecord(NewRecordViewModel viewModel)
        {
            var record = viewModel.Map();
            bool successful = true;

            try
            {
                _recordService.InsertRecord(record);
            }
            catch (Exception)
            {
                successful = false;
            }

            return Json(successful);
        }
    }
}