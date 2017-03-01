namespace BroadbandSpeedStats.Database.Schema
{
    public static class Views
    {
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
    }
}
