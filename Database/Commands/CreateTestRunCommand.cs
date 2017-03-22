using System;
using System.Data;
using System.Data.SqlClient;
using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Commands
{
    public sealed class CreateTestRunCommand
    {
        private readonly IConnectionStringProvider connectionStringProvider;

        public CreateTestRunCommand(IConnectionStringProvider connectionStringProvider)
        {
            if (connectionStringProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionStringProvider));
            }

            this.connectionStringProvider = connectionStringProvider;
        }

        public void Execute(DateTime timestamp, float pingTime, float downloadSpeed, float uploadSpeed,
            string serverId, string serverName, string serverHost, string serverUrl, string serverUrl2,
            float serverLatency, float serverDistance, string serverLatitude, string serverLongitude,
            string serverCountry, string serverCountryCode, string serverSponsor)
        {
            var connectionString = connectionStringProvider.GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
INSERT INTO {Tables.TestRuns.Name}
(
    [{Tables.TestRuns.Columns.Timestamp}],
    [{Tables.TestRuns.Columns.PingTime}],
    [{Tables.TestRuns.Columns.DownloadSpeed}],
    [{Tables.TestRuns.Columns.UploadSpeed}],
    [{Tables.TestRuns.Columns.ServerId}],
    [{Tables.TestRuns.Columns.ServerName}],
    [{Tables.TestRuns.Columns.ServerHost}],
    [{Tables.TestRuns.Columns.ServerUrl}],
    [{Tables.TestRuns.Columns.ServerUrl2}],
    [{Tables.TestRuns.Columns.ServerLatency}],
    [{Tables.TestRuns.Columns.ServerDistance}],
    [{Tables.TestRuns.Columns.ServerLatitude}],
    [{Tables.TestRuns.Columns.ServerLongitude}],
    [{Tables.TestRuns.Columns.ServerCountry}],
    [{Tables.TestRuns.Columns.ServerCountryCode}],
    [{Tables.TestRuns.Columns.ServerSponsor}]
)
VALUES
(
    @timestamp,
    @pingTime,
    @downloadSpeed,
    @uploadSpeed,
    @serverId,
    @serverName,
    @serverHost,
    @serverUrl,
    @serverUrl2,
    @serverLatency,
    @serverDistance,
    @serverLatitude,
    @serverLongitude,
    @serverCountry,
    @serverCountryCode,
    @serverSponsor
)
";

                    command.Parameters.Add("@timestamp", SqlDbType.NVarChar).Value = timestamp;
                    command.Parameters.Add("@pingTime", SqlDbType.Float).Value = pingTime;
                    command.Parameters.Add("@downloadSpeed", SqlDbType.Float).Value = downloadSpeed;
                    command.Parameters.Add("@uploadSpeed", SqlDbType.Float).Value = uploadSpeed;
                    command.Parameters.Add("@serverId", SqlDbType.NVarChar, 6).Value = serverId;
                    command.Parameters.Add("@serverName", SqlDbType.NVarChar, 255).Value = serverName;
                    command.Parameters.Add("@serverHost", SqlDbType.NVarChar, 255).Value = serverHost;
                    command.Parameters.Add("@serverUrl", SqlDbType.NVarChar, 255).Value = serverUrl;
                    command.Parameters.Add("@serverUrl2", SqlDbType.NVarChar, 255).Value = serverUrl2;
                    command.Parameters.Add("@serverLatency", SqlDbType.Float).Value = serverLatency;
                    command.Parameters.Add("@serverDistance", SqlDbType.Float).Value = serverDistance;
                    command.Parameters.Add("@serverLatitude", SqlDbType.NVarChar, 15).Value = serverLatitude;
                    command.Parameters.Add("@serverLongitude", SqlDbType.NVarChar, 15).Value = serverLongitude;
                    command.Parameters.Add("@serverCountry", SqlDbType.NVarChar, 255).Value = serverCountry;
                    command.Parameters.Add("@serverCountryCode", SqlDbType.NVarChar, 3).Value = serverCountryCode;
                    command.Parameters.Add("@serverSponsor", SqlDbType.NVarChar, 255).Value = serverSponsor;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
