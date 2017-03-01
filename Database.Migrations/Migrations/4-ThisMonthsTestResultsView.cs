using BroadbandSpeedStats.Database.Schema;
using FluentMigrator;

namespace BroadbandSpeedTests.Database.Migrations.Migrations
{
    [Migration(20170300)]
    public class ThisMonthsTestResultsView : Migration
    {
        public override void Up()
        {
            Execute.Sql($@"
CREATE VIEW [{Views.ThisMonthsTestResults.Name}] WITH SCHEMABINDING AS
    SELECT TOP 100 PERCENT [{Views.ThisMonthsTestResults.Columns.Id}],
                           [{Views.ThisMonthsTestResults.Columns.Timestamp}],
                           [{Views.ThisMonthsTestResults.Columns.PingTime}],
                           [{Views.ThisMonthsTestResults.Columns.DownloadSpeed}],
                           [{Views.ThisMonthsTestResults.Columns.UploadSpeed}]
    FROM [dbo].[{Views.ThisMonthsTestResults.SourceTable}]
    WHERE DATEDIFF(m, {Views.ThisMonthsTestResults.Columns.Timestamp}, GETUTCDATE()) = 0
    ORDER BY [{Views.ThisMonthsTestResults.Columns.Timestamp}] DESC
GO");
        }

        public override void Down()
        {
            Execute.Sql($"DROP VIEW [{Views.ThisMonthsTestResults.Name}]");
        }
    }
}
