using System;
using System.Collections.Generic;
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
    }
}