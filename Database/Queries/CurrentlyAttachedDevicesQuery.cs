using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BroadbandStats.Database.Models;
using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Queries
{
    public sealed class CurrentlyAttachedDevicesQuery
    {
        private readonly IConnectionStringProvider connectionStringProvider;

        public CurrentlyAttachedDevicesQuery(IConnectionStringProvider connectionStringProvider)
        {
            if (connectionStringProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionStringProvider));
            }

            this.connectionStringProvider = connectionStringProvider;
        }

        public IEnumerable<ConnectedDevice> Run()
        {
            var connectionString = connectionStringProvider.GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM [dbo].[{Views.CurrentDeviceSnapshot.Name}]";
                    var latestSnapshotId = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = $@"SELECT * FROM [dbo].[{Views.CurrentlyConnectedDevices.Name}]
WHERE [{Views.CurrentlyConnectedDevices.Columns.SnapshotId}] = {latestSnapshotId}
ORDER BY [{Views.CurrentlyConnectedDevices.Columns.DeviceName}] ASC";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var deviceId = reader.GetInt32(reader.GetOrdinal(Views.CurrentlyConnectedDevices.Columns.DeviceId));
                            var deviceName = reader.GetString(reader.GetOrdinal(Views.CurrentlyConnectedDevices.Columns.DeviceName));
                            var macAddress = reader.GetString(reader.GetOrdinal(Views.CurrentlyConnectedDevices.Columns.MacAddress));
                            var ipAddress = reader.GetString(reader.GetOrdinal(Views.CurrentlyConnectedDevices.Columns.IpAddress));
                            var description = reader.GetString(reader.GetOrdinal(Views.CurrentlyConnectedDevices.Columns.DeviceDescription));
                            var connectionType = reader.GetString(reader.GetOrdinal(Views.CurrentlyConnectedDevices.Columns.ConnectionType));

                            yield return new ConnectedDevice(deviceId, deviceName, macAddress, ipAddress, description, connectionType);
                        }
                    }
                }
            }
        }
    }
}
