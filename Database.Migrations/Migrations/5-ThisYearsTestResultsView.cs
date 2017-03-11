using BroadbandStats.Database.Schema;
using FluentMigrator;

namespace BroadbandStats.Database.Migrations.Migrations
{
    [Migration(20170304)]
    public class ThisYearsTestResultsView : Migration
    {
        public override void Up()
        {
            Execute.Sql($@"
CREATE VIEW [{Views.ThisYearsTestResults.Name}] WITH SCHEMABINDING AS
    SELECT TOP 100 PERCENT [{Views.ThisYearsTestResults.Columns.Id}],
                           [{Views.ThisYearsTestResults.Columns.Timestamp}],
                           [{Views.ThisYearsTestResults.Columns.PingTime}],
                           [{Views.ThisYearsTestResults.Columns.DownloadSpeed}],
                           [{Views.ThisYearsTestResults.Columns.UploadSpeed}]
    FROM [dbo].[{Views.ThisYearsTestResults.SourceTable}]
    WHERE DATEDIFF(yy, {Views.ThisYearsTestResults.Columns.Timestamp}, GETUTCDATE()) = 0
    ORDER BY [{Views.ThisYearsTestResults.Columns.Timestamp}] DESC
GO");
        }

        public override void Down()
        {
            Execute.Sql($"DROP VIEW [{Views.ThisMonthsTestResults.Name}]");
        }
    }
}
