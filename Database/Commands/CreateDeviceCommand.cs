using System;
using System.Data.SqlClient;
using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Commands
{
    public sealed class CreateDeviceCommand
    {
        private readonly IConnectionStringProvider connectionStringProvider;

        public CreateDeviceCommand(IConnectionStringProvider connectionStringProvider)
        {
            if (connectionStringProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionStringProvider));
            }

            this.connectionStringProvider = connectionStringProvider;
        }

        public int Execute(string deviceName, string deviceMacAddress)
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
    [{Tables.Devices.Columns.DeviceName}],
    [{Tables.Devices.Columns.MacAddress}]
)
VALUES
(
    '{deviceName}',
    '{deviceMacAddress}'
)

SELECT SCOPE_IDENTITY();
";
                    var deviceId = Convert.ToInt32(command.ExecuteScalar());
                    return deviceId;
                }
            }
        }
    }
}