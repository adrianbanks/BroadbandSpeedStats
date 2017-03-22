using System;
using System.Data;
using System.Data.SqlClient;
using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Commands
{
    public sealed class CreateTrafficStatsCommand
    {
        private readonly IConnectionStringProvider connectionStringProvider;

        public CreateTrafficStatsCommand(IConnectionStringProvider connectionStringProvider)
        {
            if (connectionStringProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionStringProvider));
            }

            this.connectionStringProvider = connectionStringProvider;
        }

        public void Execute(DateTime timestamp, float download, float upload)
        {
            var connectionString = connectionStringProvider.GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
INSERT INTO {Tables.TrafficStats.Name}
(
    [{Tables.TrafficStats.Columns.Timestamp}],
    [{Tables.TrafficStats.Columns.Download}],
    [{Tables.TrafficStats.Columns.Upload}]
)
VALUES
(
    '{timestamp:yyyy-MM-d HH:mm:ss}',
    {download},
    {upload}
)
";
                    command.Parameters.Add("@timestamp", SqlDbType.DateTime).Value = timestamp;
                    command.Parameters.Add("@download", SqlDbType.Float).Value = download;
                    command.Parameters.Add("@upload", SqlDbType.Float).Value = upload;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
