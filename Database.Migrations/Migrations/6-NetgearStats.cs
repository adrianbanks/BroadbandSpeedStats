using BroadbandStats.Database.Schema;
using FluentMigrator;

namespace BroadbandStats.Database.Migrations.Migrations
{
    [Migration(20170312)]
    public class NetgearStats : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.TrafficStats.Name)
                .WithColumn(Tables.TrafficStats.Columns.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Tables.TrafficStats.Columns.Timestamp).AsDateTime().NotNullable()
                .WithColumn(Tables.TrafficStats.Columns.Download).AsFloat().NotNullable()
                .WithColumn(Tables.TrafficStats.Columns.Upload).AsFloat().NotNullable();

            Create.Table(Tables.AttachedDevices.Name)
                .WithColumn(Tables.AttachedDevices.Columns.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Tables.AttachedDevices.Columns.Timestamp).AsDateTime().NotNullable()
                .WithColumn(Tables.AttachedDevices.Columns.DeviceCount).AsInt32().NotNullable();

            Create.Table(Tables.Devices.Name)
                .WithColumn(Tables.Devices.Columns.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Tables.Devices.Columns.SnapshotId).AsInt32().NotNullable()
                .WithColumn(Tables.Devices.Columns.DeviceName).AsString(255).NotNullable()
                .WithColumn(Tables.Devices.Columns.IpAddress).AsString(15).NotNullable()
                .WithColumn(Tables.Devices.Columns.MacAddress).AsString(17).NotNullable()
                .WithColumn(Tables.Devices.Columns.ConnectionType).AsString(255).NotNullable();

            Create.ForeignKey()
                .FromTable(Tables.Devices.Name).ForeignColumn(Tables.Devices.Columns.SnapshotId)
                .ToTable(Tables.AttachedDevices.Name).PrimaryColumn(Tables.AttachedDevices.Columns.Id);
        }

        public override void Down()
        {
            Delete.Table(Tables.Devices.Name);
            Delete.Table(Tables.AttachedDevices.Name);
            Delete.Table(Tables.TrafficStats.Name);
        }
    }
}
