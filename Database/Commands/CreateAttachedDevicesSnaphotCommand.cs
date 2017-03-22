using System;
using System.Data;
using System.Data.SqlClient;
using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Commands
{
    public sealed class CreateAttachedDevicesSnaphotCommand
    {
        private readonly IConnectionStringProvider connectionStringProvider;

        public CreateAttachedDevicesSnaphotCommand(IConnectionStringProvider connectionStringProvider)
        {
            if (connectionStringProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionStringProvider));
            }

            this.connectionStringProvider = connectionStringProvider;
        }

        public int Execute(DateTime timestamp, int attachedDeviceCount)
        {
            var connectionString = connectionStringProvider.GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
INSERT INTO {Tables.AttachedDeviceSnapshots.Name}
(
    [{Tables.AttachedDeviceSnapshots.Columns.Timestamp}],
    [{Tables.AttachedDeviceSnapshots.Columns.DeviceCount}]
)
VALUES
(
    @timestamp,
    @attachedDeviceCount
)

SELECT SCOPE_IDENTITY();
";
                    command.Parameters.Add("@timestamp", SqlDbType.DateTime).Value = timestamp;
                    command.Parameters.Add("@attachedDeviceCount", SqlDbType.Int).Value = attachedDeviceCount;

                    var snapshotIdentity = Convert.ToInt32(command.ExecuteScalar());
                    return snapshotIdentity;
                }
            }
        }
    }
}
