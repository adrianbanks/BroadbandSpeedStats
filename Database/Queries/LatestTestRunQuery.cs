using System.Data.SqlClient;
using BroadbandSpeedStats.Database.Models;
using BroadbandSpeedStats.Database.Schema;

namespace BroadbandSpeedStats.Database.Queries
{
    public class LatestTestRunQuery
    {
        public TestRunResult Run(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM {Views.LatestTestRun.Name}";

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var timestamp = reader.GetDateTime(reader.GetOrdinal(Views.LatestTestRun.Columns.Timestamp));
                            var pingTime = reader.GetFloat(reader.GetOrdinal(Views.LatestTestRun.Columns.PingTime));
                            var downloadSpeed = reader.GetFloat(reader.GetOrdinal(Views.LatestTestRun.Columns.DownloadSpeed));
                            var uploadSpeed = reader.GetFloat(reader.GetOrdinal(Views.LatestTestRun.Columns.UploadSpeed));

                            return new TestRunResult(timestamp, pingTime, downloadSpeed, uploadSpeed);
                        }
                    }
                }
            }

            return null;
        }
    }
}
