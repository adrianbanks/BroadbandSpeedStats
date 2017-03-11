using BroadbandStats.Database.Schema;
using FluentMigrator;

namespace BroadbandStats.Database.Migrations.Migrations
{
    [Migration(20170212)]
    public class InitialDatabase : Migration
    {
        public override void Up()
        {
            CreateTestRunsTable();
            CreateLatestTestRunView();
        }

        private void CreateTestRunsTable()
        {
            Create.Table(Tables.TestRuns.Name)
                .WithColumn(Tables.TestRuns.Columns.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Tables.TestRuns.Columns.Timestamp).AsDateTime().NotNullable()
                .WithColumn(Tables.TestRuns.Columns.PingTime).AsFloat().NotNullable()
                .WithColumn(Tables.TestRuns.Columns.DownloadSpeed).AsFloat().NotNullable()
                .WithColumn(Tables.TestRuns.Columns.UploadSpeed).AsFloat().NotNullable();

            Create.Index("IX_TestRuns_Timestamp")
                .OnTable(Tables.TestRuns.Name)
                .OnColumn(Tables.TestRuns.Columns.Timestamp);
        }

        private void CreateLatestTestRunView()
        {
            Execute.Sql($@"
CREATE VIEW [{Views.LatestTestRun.Name}] WITH SCHEMABINDING AS
    SELECT TOP 1 [{Views.LatestTestRun.Columns.Id}],
                 [{Views.LatestTestRun.Columns.Timestamp}],
                 [{Views.LatestTestRun.Columns.PingTime}],
                 [{Views.LatestTestRun.Columns.DownloadSpeed}],
                 [{Views.LatestTestRun.Columns.UploadSpeed}]
    FROM [dbo].[{Views.LatestTestRun.SourceTable}]
    ORDER BY [{Views.LatestTestRun.Columns.Timestamp}] DESC
GO");
        }

        public override void Down()
        {
            Delete.Table(Tables.TestRuns.Name);
            Execute.Sql($"DROP VIEW [{Views.LatestTestRun.Name}]");
        }
    }
}
