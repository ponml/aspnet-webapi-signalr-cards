using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace game_app_server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
