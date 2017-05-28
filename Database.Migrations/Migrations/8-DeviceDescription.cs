using BroadbandStats.Database.Schema;
using FluentMigrator;

namespace BroadbandStats.Database.Migrations.Migrations
{
    [Migration(20170407)]
    public class DeviceDescription : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Devices.Name).AddColumn(Tables.Devices.Columns.Description).AsString(255).Nullable();
        }

        public override void Down()
        {
            Delete.Column(Tables.Devices.Columns.Description).FromTable(Tables.Devices.Name);
        }
    }
}
