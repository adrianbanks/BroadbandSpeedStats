using BroadbandStats.Database.Schema;
using FluentMigrator;

namespace BroadbandStats.Database.Migrations.Migrations
{
    [Migration(20170528)]
    public class CurrentDevices : Migration
    {
        public override void Up()
        {
            Execute.Sql($@"
CREATE VIEW [{Views.CurrentDeviceSnapshot.Name}] WITH SCHEMABINDING AS
    SELECT MAX([{Tables.AttachedDevices.Columns.SnapshotId}]) AS [{Tables.AttachedDevices.Columns.SnapshotId}]
    FROM [dbo].[{Tables.AttachedDevices.Name}]
GO");

            Execute.Sql($@"
CREATE VIEW [{Views.CurrentlyConnectedDevices.Name}] WITH SCHEMABINDING AS
    SELECT AD.[{Tables.AttachedDevices.Columns.SnapshotId}],
            D.[{Tables.Devices.Columns.Id}],
            ADS.[{Tables.AttachedDeviceSnapshots.Columns.Timestamp}],
            D.[{Tables.Devices.Columns.DeviceName}],
            ISNULL(D.[{Tables.Devices.Columns.Description}], '') AS [{Tables.Devices.Columns.Description}],
            D.[{Tables.Devices.Columns.MacAddress}],
            AD.[{Tables.AttachedDevices.Columns.IpAddress}],
            AD.[{Tables.AttachedDevices.Columns.ConnectionType}]
    FROM [dbo].[{Tables.Devices.Name}] D,
            [dbo].[{Tables.AttachedDevices.Name}] AD,
            [dbo].[{Tables.AttachedDeviceSnapshots.Name}] ADS
    WHERE D.[{Tables.Devices.Columns.Id}] = AD.[{Tables.AttachedDevices.Columns.DeviceId}]
    AND AD.[{Tables.AttachedDevices.Columns.SnapshotId}] = ADS.[{Tables.AttachedDeviceSnapshots.Columns.Id}]
GO");
        }

        public override void Down()
        {
            Execute.Sql($"DROP VIEW [{Views.CurrentlyConnectedDevices.Name}]");
            Execute.Sql($"DROP VIEW [{Views.CurrentDeviceSnapshot.Name}]");
        }
    }
}