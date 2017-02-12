using System;
using System.Data.SqlClient;
using BroadbandSpeedStats.Database.Schema;

namespace BroadbandSpeedStats.Database.Commands
{
    public class CreateTestRunCommand
    {
        public void Execute(string connectionString, DateTime timestamp, float pingTime, float downloadSpeed, float uploadSpeed)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
INSERT INTO {Tables.TestRuns.Name}
([{Tables.TestRuns.Columns.Timestamp}], [{Tables.TestRuns.Columns.PingTime}], [{Tables.TestRuns.Columns.DownloadSpeed}], [{Tables.TestRuns.Columns.UploadSpeed}])
VALUES
('{timestamp:yyyy-MM-d HH:mm:ss}', {pingTime}, {downloadSpeed}, {uploadSpeed})
";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
