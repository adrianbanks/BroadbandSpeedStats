using System;
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
    '{timestamp:yyyy-MM-d HH:mm:ss}',
    {attachedDeviceCount}
)

SELECT SCOPE_IDENTITY();
";
                    var snapshotIdentity = Convert.ToInt32(command.ExecuteScalar());
                    return snapshotIdentity;
                }
            }
        }
    }
}
