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
        }

        public override void Down()
        {
            Delete.Table(Tables.TrafficStats.Name);
        }
    }
}
