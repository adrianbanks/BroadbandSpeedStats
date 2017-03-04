using System.Collections.Generic;
using System.Data.SqlClient;
using BroadbandSpeedStats.Database.Models;
using BroadbandSpeedStats.Database.Schema;

namespace BroadbandSpeedStats.Database.Queries
{
    public abstract class GetTestRunResultsFromViewQuery
    {
        protected abstract string ViewName { get; }

        public IEnumerable<TestRunResult> Run(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM {ViewName}";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var timestamp = reader.GetDateTime(reader.GetOrdinal(Tables.TestRuns.Columns.Timestamp));
                            var pingTime = reader.GetFloat(reader.GetOrdinal(Tables.TestRuns.Columns.PingTime));
                            var downloadSpeed = reader.GetFloat(reader.GetOrdinal(Tables.TestRuns.Columns.DownloadSpeed));
                            var uploadSpeed = reader.GetFloat(reader.GetOrdinal(Tables.TestRuns.Columns.UploadSpeed));

                            yield return new TestRunResult(timestamp, pingTime, downloadSpeed, uploadSpeed);
                        }
                    }
                }
            }
        }
    }
}
