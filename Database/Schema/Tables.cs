namespace BroadbandStats.Database.Schema
{
    public static class Tables
    {
        public static class TestRuns
        {
           public const string Name = nameof(TestRuns);

            public static class Columns
            {
                public const string Id                  = "TestId";
                public const string Timestamp           = "Timestamp";
                public const string PingTime            = "PingTime";
                public const string DownloadSpeed       = "DownloadSpeed";
                public const string UploadSpeed         = "UploadSpeed";
                public const string ServerId            = "ServerId";
                public const string ServerName          = "ServerName";
                public const string ServerHost          = "ServerHost";
                public const string ServerUrl           = "ServerUrl";
                public const string ServerUrl2          = "ServerUrl2";
                public const string ServerLatency       = "ServerLatency";
                public const string ServerDistance      = "ServerDistance";
                public const string ServerLatitude      = "ServerLatitude";
                public const string ServerLongitude     = "ServerLongitude";
                public const string ServerCountry       = "ServerCountry";
                public const string ServerCountryCode   = "ServerCountryCode";
                public const string ServerSponsor       = "ServerSponsor";
            }
        }

        public static class TrafficStats
        {
            public const string Name = nameof(TrafficStats);

            public static class Columns
            {
                public const string Id                  = "Id";
                public const string Timestamp           = "Timestamp";
                public const string Download            = "Download";
                public const string Upload              = "Upload";
            }
        }

        public static class AttachedDeviceSnapshots
        {
            public const string Name = nameof(AttachedDeviceSnapshots);

            public static class Columns
            {
                public const string Id                  = "SnapshotId";
                public const string Timestamp           = "Timestamp";
                public const string DeviceCount         = "DeviceCount";
            }
        }

        public static class Devices
        {
            public const string Name = nameof(Devices);

            public static class Columns
            {
                public const string Id                  = "DeviceId";
                public const string DeviceName          = "Name";
                public const string MacAddress          = "MacAddress";
                public const string Description         = "Description";
            }
        }

        public static class AttachedDevices
        {
            public const string Name = nameof(AttachedDevices);

            public static class Columns
            {
                public const string Id                  = "Id";
                public const string SnapshotId          = "SnapshotId";
                public const string DeviceId            = "DeviceId";
                public const string IpAddress           = "IpAddress";
                public const string ConnectionType      = "ConnectionType";
            }
        }
    }
}
