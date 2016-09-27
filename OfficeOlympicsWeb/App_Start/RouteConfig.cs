using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OfficeOlympicsWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AdminEditEvent",
                url: "Admin/EditEvent/{olympicEventId}",
                defaults: new { controller = "Admin", action = "EditEvent" }
            );

            routes.MapRoute(
                name: "AdminEditCompetitor",
                url: "Admin/EditCompetitor/{competitorId}",
                defaults: new { controller = "Admin", action = "EditCompetitor" }
            );

            routes.MapRoute(
                name: "AdminErrorLog",
                url: "Admin/ErrorLog/{pageNumber}",
                defaults: new { controller = "Admin", action = "ErrorLog", pageNumber = 1 }
            );

            routes.MapRoute(
                name: "HomeRecords",
                url: "Home/Records/{olympicEventId}",
                defaults: new { controller = "Home", action = "Records", olympicEventId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "HomeNewRecord",
                url: "Home/NewRecord/{olympicEventId}",
                defaults: new { controller = "Home", action = "NewRecord" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
