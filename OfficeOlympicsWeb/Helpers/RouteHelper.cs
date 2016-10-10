using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OfficeOlympicsWeb.Helpers
{
    public static class RouteHelper
    {
        public static RouteValueDictionary NullifiedRouteValues(this HtmlHelper html, params string[] routeKeys)
        {
            var dictionary = new Dictionary<string, object>();

            foreach (string key in routeKeys)
            {
                dictionary[key] = null;
            }

            return new RouteValueDictionary(dictionary);
        }

        public static RouteValueDictionary GetRouteDataFromUrl(string url)
        {
            var request = new HttpRequest(null, url, null);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            return routeData.Values;
        }
    }
}