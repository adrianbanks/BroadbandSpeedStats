using System;
using BroadbandStats.Database.Commands;
using BroadbandStats.Website.Models;
using Nancy;
using Nancy.ModelBinding;

namespace BroadbandStats.Website.Modules.SpeedStats
{
    public class SpeedStatsApiModule : NancyModule
    {
        public SpeedStatsApiModule(CreateTestRunCommand createTestRunCommand) : base("/speed")
        {
            if (createTestRunCommand == null)
            {
                throw new ArgumentNullException(nameof(createTestRunCommand));
            }

            Post["/RecordSpeedTest"] = _ =>
            {
                var speedTestResult = this.Bind<SpeedTestResultRequest>();
                return RecordSpeedTest(createTestRunCommand, speedTestResult);
            };
        }

        private HttpStatusCode RecordSpeedTest(CreateTestRunCommand command, SpeedTestResultRequest result)
        {
            var server = result.Server;
            var downloadSpeedInMbitPerSecond = result.Download / 1000000;
            var uploadSpeedInMbitPerSecond = result.Upload / 1000000;
            command.Execute(
                result.Timestamp, result.Ping, downloadSpeedInMbitPerSecond, uploadSpeedInMbitPerSecond,
                server.Id, server.Name, server.Host, server.Url, server.Url2,
                server.Latency, server.D, server.Lat, server.Lon,
                server.Country, server.Cc, server.Sponsor);

            return HttpStatusCode.Created;
        }
   }
}