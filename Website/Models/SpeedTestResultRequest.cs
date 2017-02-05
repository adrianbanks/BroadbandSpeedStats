using System;

namespace BroadbandSpeedStats.Models
{
    public class SpeedTestResultRequest
    {
        public DateTime DateTime { get; set; }
        public float Ping { get; set; }
        public float Download { get; set; }
        public float Upload { get; set; }
    }
}
