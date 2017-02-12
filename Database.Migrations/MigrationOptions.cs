using FluentMigrator;

namespace BroadbandSpeedTests.Database.Migrations
{
    internal sealed class MigrationOptions : IMigrationProcessorOptions
    {
        public bool PreviewOnly { get; set; }
        public int Timeout { get; set; }
        public string ProviderSwitches { get; set; }
    }
}
