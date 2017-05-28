namespace BroadbandStats.Database.Schema
{
    public static class Views
    {
        public static class CurrentDeviceSnapshot
        {
            public const string Name = "CurrentDeviceSnapshot";
            public const string SourceTable = Tables.AttachedDevices.Name;

            public static class Columns
            {
                public const string SnapshotId        = Tables.AttachedDevices.Columns.SnapshotId;
            }
        }

        public static class CurrentlyConnectedDevices
        {
            public const string Name = "CurrentlyConnectedDevices";
            public const string SourceTable = Tables.Devices.Name;

            public static class Columns
            {
                public const string DeviceId          = Tables.Devices.Columns.Id;
                public const string DeviceName        = Tables.Devices.Columns.DeviceName;
                public const string DeviceDescription = Tables.Devices.Columns.Description;
                public const string MacAddress        = Tables.Devices.Columns.MacAddress;
                public const string IpAddress         = Tables.AttachedDevices.Columns.IpAddress;
                public const string ConnectionType    = Tables.AttachedDevices.Columns.ConnectionType;
                public const string SnapshotId        = Tables.AttachedDeviceSnapshots.Columns.Id;
            }
        }

        public static class LatestTestRun
        {
            public const string Name = "LatestTestRun";
            public const string SourceTable = Tables.TestRuns.Name;

            public static class Columns
            {
                public const string Id              = Tables.TestRuns.Columns.Id;
                public const string Timestamp       = Tables.TestRuns.Columns.Timestamp;
                public const string PingTime        = Tables.TestRuns.Columns.PingTime;
                public const string DownloadSpeed   = Tables.TestRuns.Columns.DownloadSpeed;
                public const string UploadSpeed     = Tables.TestRuns.Columns.UploadSpeed;
            }
        }

        public static class TodaysTestResults
        {
            public const string Name = "TodaysTestResults";
            public const string SourceTable = Tables.TestRuns.Name;

            public static class Columns
            {
                public const string Id              = Tables.TestRuns.Columns.Id;
                public const string Timestamp       = Tables.TestRuns.Columns.Timestamp;
                public const string PingTime        = Tables.TestRuns.Columns.PingTime;
                public const string DownloadSpeed   = Tables.TestRuns.Columns.DownloadSpeed;
                public const string UploadSpeed     = Tables.TestRuns.Columns.UploadSpeed;
            }
        }

        public static class ThisWeeksTestResults
        {
            public const string Name = "ThisWeeksTestResults";
            public const string SourceTable = Tables.TestRuns.Name;

            public static class Columns
            {
                public const string Id              = Tables.TestRuns.Columns.Id;
                public const string Timestamp       = Tables.TestRuns.Columns.Timestamp;
                public const string PingTime        = Tables.TestRuns.Columns.PingTime;
                public const string DownloadSpeed   = Tables.TestRuns.Columns.DownloadSpeed;
                public const string UploadSpeed     = Tables.TestRuns.Columns.UploadSpeed;
            }
        }

        public static class ThisMonthsTestResults
        {
            public const string Name = "ThisMonthsTestResults";
            public const string SourceTable = Tables.TestRuns.Name;

            public static class Columns
            {
                public const string Id              = Tables.TestRuns.Columns.Id;
                public const string Timestamp       = Tables.TestRuns.Columns.Timestamp;
                public const string PingTime        = Tables.TestRuns.Columns.PingTime;
                public const string DownloadSpeed   = Tables.TestRuns.Columns.DownloadSpeed;
                public const string UploadSpeed     = Tables.TestRuns.Columns.UploadSpeed;
            }
        }

        public static class ThisYearsTestResults
        {
            public const string Name = "ThisYearsTestResults";
            public const string SourceTable = Tables.TestRuns.Name;

            public static class Columns
            {
                public const string Id              = Tables.TestRuns.Columns.Id;
                public const string Timestamp       = Tables.TestRuns.Columns.Timestamp;
                public const string PingTime        = Tables.TestRuns.Columns.PingTime;
                public const string DownloadSpeed   = Tables.TestRuns.Columns.DownloadSpeed;
                public const string UploadSpeed     = Tables.TestRuns.Columns.UploadSpeed;
            }
        }
    }
}
