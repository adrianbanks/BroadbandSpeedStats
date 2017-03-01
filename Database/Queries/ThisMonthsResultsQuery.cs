﻿using System.Collections.Generic;
using System.Data.SqlClient;
using BroadbandSpeedStats.Database.Models;
using BroadbandSpeedStats.Database.Schema;

namespace BroadbandSpeedStats.Database.Queries
{
    public class ThisMonthsResultsQuery
    {
        public IEnumerable<TestRunResult> Run(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM {Views.ThisMonthsTestResults.Name}";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var timestamp = reader.GetDateTime(reader.GetOrdinal(Views.ThisMonthsTestResults.Columns.Timestamp));
                            var pingTime = reader.GetFloat(reader.GetOrdinal(Views.ThisMonthsTestResults.Columns.PingTime));
                            var downloadSpeed = reader.GetFloat(reader.GetOrdinal(Views.ThisMonthsTestResults.Columns.DownloadSpeed));
                            var uploadSpeed = reader.GetFloat(reader.GetOrdinal(Views.ThisMonthsTestResults.Columns.UploadSpeed));

                            yield return new TestRunResult(timestamp, pingTime, downloadSpeed, uploadSpeed);
                        }
                    }
                }
            }
        }
    }
}
