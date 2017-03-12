using System;
using System.Data.SqlClient;
using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Commands
{
    public sealed class CreateDeviceSnapshotEntryCommand
    {
        private readonly IConnectionStringProvider connectionStringProvider;

        public CreateDeviceSnapshotEntryCommand(IConnectionStringProvider connectionStringProvider)
        {
            if (connectionStringProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionStringProvider));
            }

            this.connectionStringProvider = connectionStringProvider;
        }

        public void Execute(int snapshotIdentity, string deviceName, string deviceIpAddress, string deviceMacAddress, string deviceConnectionType)
        {
            var connectionString = connectionStringProvider.GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
INSERT INTO {Tables.Devices.Name}
(
    [{Tables.Devices.Columns.SnapshotId}],
    [{Tables.Devices.Columns.DeviceName}],
    [{Tables.Devices.Columns.IpAddress}],
    [{Tables.Devices.Columns.MacAddress}],
    [{Tables.Devices.Columns.ConnectionType}]
)
VALUES
(
    {snapshotIdentity},
    '{deviceName}',
    '{deviceIpAddress}',
    '{deviceMacAddress}',
    '{deviceConnectionType}'
)
";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
