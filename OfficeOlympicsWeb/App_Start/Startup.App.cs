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
            app.MapSignalR();
        }
    }
}