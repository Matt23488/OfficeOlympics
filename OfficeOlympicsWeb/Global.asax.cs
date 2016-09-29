using OfficeOlympicsLib.Services.Interfaces;
using OfficeOlympicsWeb.App_Start;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OfficeOlympicsWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            var errorLog = UnityConfig.GetConfiguredContainer().Resolve<IErrorLogger>();

            if (HttpContext.Current != null)
            {
                foreach (var error in HttpContext.Current.AllErrors)
                {
                    errorLog.LogError(error);
                }
            }
        }
    }
}
