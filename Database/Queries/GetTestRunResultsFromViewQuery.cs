using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BroadbandStats.Database.Models;
using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Queries
{
    public abstract class GetTestRunResultsFromViewQuery
    {
        private readonly IConnectionStringProvider connectionStringProvider;

        protected GetTestRunResultsFromViewQuery(IConnectionStringProvider connectionStringProvider)
        {
            if (connectionStringProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionStringProvider));
            }

            this.connectionStringProvider = connectionStringProvider;
        }

        protected abstract string ViewName { get; }

        public IEnumerable<TestRunResult> Run()
        {
            var connectionString = connectionStringProvider.GetConnectionString();

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
