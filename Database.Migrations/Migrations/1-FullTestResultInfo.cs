using BroadbandSpeedStats.Database.Schema;
using FluentMigrator;

namespace BroadbandSpeedTests.Database.Migrations.Migrations
{
    [Migration(20170217)]
    public class FullTestResultInfo : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.TestRuns.Name)
                .AddColumn(Tables.TestRuns.Columns.ServerId).AsString(6).Nullable()
                .AddColumn(Tables.TestRuns.Columns.ServerName).AsString(255).Nullable()
                .AddColumn(Tables.TestRuns.Columns.ServerHost).AsString(255).Nullable()
                .AddColumn(Tables.TestRuns.Columns.ServerUrl).AsString(255).Nullable()
                .AddColumn(Tables.TestRuns.Columns.ServerUrl2).AsString(255).Nullable()
                .AddColumn(Tables.TestRuns.Columns.ServerLatency).AsFloat().Nullable()
                .AddColumn(Tables.TestRuns.Columns.ServerDistance).AsFloat().Nullable()
                .AddColumn(Tables.TestRuns.Columns.ServerLatitude).AsString(15).Nullable()
                .AddColumn(Tables.TestRuns.Columns.ServerLongitude).AsString(15).Nullable()
                .AddColumn(Tables.TestRuns.Columns.ServerCountry).AsString(255).Nullable()
                .AddColumn(Tables.TestRuns.Columns.ServerCountryCode).AsString(3).Nullable()
                .AddColumn(Tables.TestRuns.Columns.ServerSponsor).AsString(255).Nullable();
        }

        public override void Down()
        {
            Delete.Column(Tables.TestRuns.Columns.ServerId).FromTable(Tables.TestRuns.Name);
            Delete.Column(Tables.TestRuns.Columns.ServerName).FromTable(Tables.TestRuns.Name);
            Delete.Column(Tables.TestRuns.Columns.ServerHost).FromTable(Tables.TestRuns.Name);
            Delete.Column(Tables.TestRuns.Columns.ServerUrl).FromTable(Tables.TestRuns.Name);
            Delete.Column(Tables.TestRuns.Columns.ServerUrl2).FromTable(Tables.TestRuns.Name);
            Delete.Column(Tables.TestRuns.Columns.ServerLatency).FromTable(Tables.TestRuns.Name);
            Delete.Column(Tables.TestRuns.Columns.ServerDistance).FromTable(Tables.TestRuns.Name);
            Delete.Column(Tables.TestRuns.Columns.ServerLatitude).FromTable(Tables.TestRuns.Name);
            Delete.Column(Tables.TestRuns.Columns.ServerLongitude).FromTable(Tables.TestRuns.Name);
            Delete.Column(Tables.TestRuns.Columns.ServerCountry).FromTable(Tables.TestRuns.Name);
            Delete.Column(Tables.TestRuns.Columns.ServerCountryCode).FromTable(Tables.TestRuns.Name);
            Delete.Column(Tables.TestRuns.Columns.ServerSponsor).FromTable(Tables.TestRuns.Name);
        }
    }
}
