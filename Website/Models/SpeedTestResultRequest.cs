using System;

namespace BroadbandSpeedStats.Web.Models
{
    public class SpeedTestResultRequest
    {
        /// <summary>
        /// The timestamp of when the test was performed.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The ping time in ms.
        /// </summary>
        public float Ping { get; set; }

        /// <summary>
        /// The download speed in bit/s.
        /// </summary>
        public float Download { get; set; }

        /// <summary>
        /// The upload speed in bit/s.
        /// </summary>
        public float Upload { get; set; }

        public Server Server { get; set; }
    }

    public class Server
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public string Url { get; set; }
        public string Url2 { get; set; }
        public float Latency { get; set; }
        public float D { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Country { get; set; }
        public string Cc { get; set; }
        public string Sponsor { get; set; }
    }
}
