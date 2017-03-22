using BroadbandStats.Database.Schema;
using FluentMigrator;

namespace BroadbandStats.Database.Migrations.Migrations
{
    [Migration(20170322)]
    public class NetgearDevices : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.Devices.Name)
                .WithColumn(Tables.Devices.Columns.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Tables.Devices.Columns.DeviceName).AsString(255).NotNullable()
                .WithColumn(Tables.Devices.Columns.MacAddress).AsString(17).NotNullable();

            Create.Table(Tables.AttachedDeviceSnapshots.Name)
                .WithColumn(Tables.AttachedDeviceSnapshots.Columns.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Tables.AttachedDeviceSnapshots.Columns.Timestamp).AsDateTime().NotNullable()
                .WithColumn(Tables.AttachedDeviceSnapshots.Columns.DeviceCount).AsInt32().NotNullable();

            Create.Table(Tables.AttachedDevices.Name)
                .WithColumn(Tables.AttachedDevices.Columns.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Tables.AttachedDevices.Columns.SnapshotId).AsInt32().NotNullable()
                .WithColumn(Tables.AttachedDevices.Columns.DeviceId).AsInt32().NotNullable()
                .WithColumn(Tables.AttachedDevices.Columns.IpAddress).AsString(15).NotNullable()
                .WithColumn(Tables.AttachedDevices.Columns.ConnectionType).AsString(255).NotNullable();

            Create.ForeignKey()
                .FromTable(Tables.AttachedDevices.Name).ForeignColumn(Tables.AttachedDevices.Columns.SnapshotId)
                .ToTable(Tables.AttachedDeviceSnapshots.Name).PrimaryColumn(Tables.AttachedDeviceSnapshots.Columns.Id);

            Create.ForeignKey()
                .FromTable(Tables.AttachedDevices.Name).ForeignColumn(Tables.AttachedDevices.Columns.DeviceId)
                .ToTable(Tables.Devices.Name).PrimaryColumn(Tables.Devices.Columns.Id);
        }

        public override void Down()
        {
            Delete.Table(Tables.AttachedDevices.Name);
            Delete.Table(Tables.AttachedDeviceSnapshots.Name);
            Delete.Table(Tables.Devices.Name);
        }
    }
}
