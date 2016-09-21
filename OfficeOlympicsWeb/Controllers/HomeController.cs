using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OfficeOlympicsWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OfficeOlympicsDbEntities"];
            ViewBag.DataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory");
            return View();
        }
    }
}