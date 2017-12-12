using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly:OwinStartup(typeof(MVCSignalR.Models.Demarrage))]
namespace MVCSignalR.Models
{
    public class Demarrage
    {
        public void Configuration(IAppBuilder app)
        {
            //GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromMinutes(1);
            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;
            hubConfiguration.EnableJSONP = false;
            app.MapSignalR(hubConfiguration);
        }
    }
}