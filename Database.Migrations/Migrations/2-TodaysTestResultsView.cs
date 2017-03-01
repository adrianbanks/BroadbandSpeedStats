using BroadbandSpeedStats.Database.Schema;
using FluentMigrator;

namespace BroadbandSpeedTests.Database.Migrations.Migrations
{
    [Migration(20170228)]
    public class TodaysTestResultsView : Migration
    {
        public override void Up()
        {
            Execute.Sql($@"
CREATE VIEW [{Views.TodaysTestResults.Name}] WITH SCHEMABINDING AS
    SELECT TOP 100 PERCENT [{Views.TodaysTestResults.Columns.Id}],
                           [{Views.TodaysTestResults.Columns.Timestamp}],
                           [{Views.TodaysTestResults.Columns.PingTime}],
                           [{Views.TodaysTestResults.Columns.DownloadSpeed}],
                           [{Views.TodaysTestResults.Columns.UploadSpeed}]
    FROM [dbo].[{Views.TodaysTestResults.SourceTable}]
    WHERE DATEDIFF(d, {Views.TodaysTestResults.Columns.Timestamp}, GETUTCDATE()) = 0
    ORDER BY [{Views.TodaysTestResults.Columns.Timestamp}] DESC
GO");
        }

        public override void Down()
        {
            Execute.Sql($"DROP VIEW [{Views.TodaysTestResults.Name}]");
        }
    }
}
