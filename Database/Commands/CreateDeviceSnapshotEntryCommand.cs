﻿using System;
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

        public void Execute(int snapshotIdentity, int deviceId, string deviceIpAddress, string deviceConnectionType)
        {
            var connectionString = connectionStringProvider.GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
INSERT INTO {Tables.AttachedDevices.Name}
(
    [{Tables.AttachedDevices.Columns.SnapshotId}],
    [{Tables.AttachedDevices.Columns.DeviceId}],
    [{Tables.AttachedDevices.Columns.IpAddress}],
    [{Tables.AttachedDevices.Columns.ConnectionType}]
)
VALUES
(
    {snapshotIdentity},
    {deviceId},
    '{deviceIpAddress}',
    '{deviceConnectionType}'
)
";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
