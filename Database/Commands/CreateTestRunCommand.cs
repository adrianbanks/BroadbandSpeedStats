using System;
using System.Data.SqlClient;
using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Commands
{
    public class CreateTestRunCommand
    {
        public void Execute(string connectionString,
            DateTime timestamp, float pingTime, float downloadSpeed, float uploadSpeed,
            string serverId, string serverName, string serverHost, string serverUrl, string serverUrl2,
            float serverLatency, float serverDistance, string serverLatitude, string serverLongitude,
            string serverCountry, string serverCountryCode, string serverSponsor)
        {
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
    '{timestamp:yyyy-MM-d HH:mm:ss}',
    {pingTime},
    {downloadSpeed},
    {uploadSpeed},
    '{serverId}',
    '{serverName}',
    '{serverHost}',
    '{serverUrl}',
    '{serverUrl2}',
    {serverLatency},
    {serverDistance},
    '{serverLatitude}',
    '{serverLongitude}',
    '{serverCountry}',
    '{serverCountryCode}',
    '{serverSponsor}'
)
";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
