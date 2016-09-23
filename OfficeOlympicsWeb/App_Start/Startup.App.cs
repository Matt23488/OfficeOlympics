using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using OfficeOlympicsLib.Services;
using OfficeOlympicsWeb.App_Start;
using OfficeOlympicsWeb.Hubs;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb
{
    public partial class Startup
    {
        public void ConfigureApp(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.Register(
                typeof(IHubActivator),
                () => new UnityHubActivator(UnityConfig.GetConfiguredContainer()));

            app.MapSignalR();
        }
    }
}