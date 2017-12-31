using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using aspnet_webapi_signalr_cards.Migrations;

[assembly: OwinStartup(typeof(aspnet_webapi_signalr_cards.Startup))]
namespace aspnet_webapi_signalr_cards
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
            // Any connection or hub wire up and configuration should go here
            Migrator.RunMigrations();
        }
    }
}
