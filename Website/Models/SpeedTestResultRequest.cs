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
    }
}
