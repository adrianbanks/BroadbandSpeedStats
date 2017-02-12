using System;

namespace BroadbandSpeedStats.Database.Models
{
    public class TestRunResult
    {
        public DateTime Timestamp { get; }
        public float PingTime { get; }
        public float DownloadSpeed { get; }
        public float UploadSpeed { get; }

        public TestRunResult(DateTime timestamp, float pingTime, float downloadSpeed, float uploadSpeed)
        {
            Timestamp = timestamp;
            PingTime = pingTime;
            DownloadSpeed = downloadSpeed;
            UploadSpeed = uploadSpeed;
        }
    }
}
