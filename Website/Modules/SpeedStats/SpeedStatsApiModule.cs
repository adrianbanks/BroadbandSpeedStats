using System;
using BroadbandStats.Database.Commands;
using BroadbandStats.Website.Models;
using Nancy;
using Nancy.ModelBinding;

namespace BroadbandStats.Website.Modules.SpeedStats
{
    public class SpeedStatsApiModule : NancyModule
    {
        public SpeedStatsApiModule(ConnectionStringProvider connectionStringProvider) : base("/speed")
        {
            if (connectionStringProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionStringProvider));
            }

            Post["/RecordSpeedTest"] = _ =>
            {
                var connectionString = connectionStringProvider.GetConnectionString();
                var speedTestResult = this.Bind<SpeedTestResultRequest>();
                return RecordSpeedTest(connectionString, speedTestResult);
            };
        }

        private HttpStatusCode RecordSpeedTest(string connectionString, SpeedTestResultRequest result)
        {
            var server = result.Server;
            var downloadSpeedInMbitPerSecond = result.Download / 1000000;
            var uploadSpeedInMbitPerSecond = result.Upload / 1000000;
            new CreateTestRunCommand().Execute(connectionString,
                result.Timestamp, result.Ping, downloadSpeedInMbitPerSecond, uploadSpeedInMbitPerSecond,
                server.Id, server.Name, server.Host, server.Url, server.Url2,
                server.Latency, server.D, server.Lat, server.Lon,
                server.Country, server.Cc, server.Sponsor);

            //response.Headers.Location = new Uri("");
            return HttpStatusCode.Created;
        }
   }
}