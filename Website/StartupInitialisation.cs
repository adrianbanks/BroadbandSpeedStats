using System.Configuration;
using BroadbandSpeedTests.Database.Migrations;
using Nancy.Bootstrapper;

namespace BroadbandSpeedTests.Website
{
    public sealed class StartupInitialisation : IApplicationStartup
    {
        public void Initialize(IPipelines pipelines)
        {
            var connectionStringEntry = ConfigurationManager.ConnectionStrings["default"];
            var migrator = new Migrator(connectionStringEntry.ConnectionString);
            migrator.MigrateToLatestSchema();
        }
    }
}
