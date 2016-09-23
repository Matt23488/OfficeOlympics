using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using OfficeOlympicsWeb.App_Start;
using Owin;

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