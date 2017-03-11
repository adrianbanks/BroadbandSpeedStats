using System.Configuration;
using BroadbandStats.Database.Migrations;
using Nancy.Bootstrapper;

namespace BroadbandStats.Website
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
