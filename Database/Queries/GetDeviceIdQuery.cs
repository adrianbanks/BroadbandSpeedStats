using System;
using System.Data;
using System.Data.SqlClient;
using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Queries
{
    public sealed class GetDeviceIdQuery
    {
        private readonly IConnectionStringProvider connectionStringProvider;

        public GetDeviceIdQuery(IConnectionStringProvider connectionStringProvider)
        {
            if (connectionStringProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionStringProvider));
            }

            this.connectionStringProvider = connectionStringProvider;
        }

        public int Run(string deviceName, string deviceMacAddress)
        {
            var connectionString = connectionStringProvider.GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
SELECT * FROM {Tables.Devices.Name}
WHERE [{Tables.Devices.Columns.DeviceName}] = @deviceName
AND [{Tables.Devices.Columns.MacAddress}] = @deviceMacAddress";

                    command.Parameters.Add("@deviceName", SqlDbType.NVarChar, 255).Value = deviceName;
                    command.Parameters.Add("@deviceMacAddress", SqlDbType.NVarChar, 17).Value = deviceMacAddress;

                    var deviceId = command.ExecuteScalar();
                    return deviceId == DBNull.Value ? 0 : Convert.ToInt32(deviceId);
                }
            }
        }
    }
}
