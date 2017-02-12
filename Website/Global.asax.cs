using System;
using System.Configuration;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using BroadbandSpeedTests.Database.Migrations;

namespace BroadbandSpeedStats.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            InitialiseDatabase();
        }

        private void InitialiseDatabase()
        {
            var connectionStringEntry = ConfigurationManager.ConnectionStrings["default"];

            if (connectionStringEntry == null)
            {
                throw new Exception("Could not find connection string to datbase");
            }

            var migrator = new Migrator(connectionStringEntry.ConnectionString);
            migrator.MigrateToLatestSchema();
        }
    }
}