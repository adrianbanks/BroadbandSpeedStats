using BroadbandStats.Database.Schema;
using FluentMigrator;

namespace BroadbandStats.Database.Migrations.Migrations
{
    [Migration(20170301)]
    public class ThisWeeksTestResultsView : Migration
    {
        public override void Up()
        {
            Execute.Sql($@"
CREATE VIEW [{Views.ThisWeeksTestResults.Name}] WITH SCHEMABINDING AS
    SELECT TOP 100 PERCENT [{Views.ThisWeeksTestResults.Columns.Id}],
                           [{Views.ThisWeeksTestResults.Columns.Timestamp}],
                           [{Views.ThisWeeksTestResults.Columns.PingTime}],
                           [{Views.ThisWeeksTestResults.Columns.DownloadSpeed}],
                           [{Views.ThisWeeksTestResults.Columns.UploadSpeed}]
    FROM [dbo].[{Views.ThisWeeksTestResults.SourceTable}]
    WHERE DATEDIFF(wk, {Views.ThisWeeksTestResults.Columns.Timestamp}, GETUTCDATE()) = 0
    ORDER BY [{Views.ThisWeeksTestResults.Columns.Timestamp}] DESC
GO");
        }

        public override void Down()
        {
            Execute.Sql($"DROP VIEW [{Views.ThisWeeksTestResults.Name}]");
        }
    }
}
