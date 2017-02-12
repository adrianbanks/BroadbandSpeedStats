namespace BroadbandSpeedStats.Database.Schema
{
    public static class Tables
    {
        public static class TestRuns
        {
           public const string Name = "TestRuns";

            public static class Columns
            {
                public const string Id              = "TestId";
                public const string Timestamp       = "Timestamp";
                public const string PingTime        = "PingTime";
                public const string DownloadSpeed   = "DownloadSpeed";
                public const string UploadSpeed     = "UploadSpeed";
            }
        }
    }
}
