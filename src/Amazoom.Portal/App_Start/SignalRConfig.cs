using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Amazoom.Portal.App_Start.Startup))]

namespace Amazoom.Portal.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
} 