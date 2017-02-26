using System;
using System.Configuration;
using BroadbandSpeedStats.Database.Commands;
using BroadbandSpeedTests.Website.Models;
using Nancy;
using Nancy.ModelBinding;

namespace BroadbandSpeedTests.Website.Modules
{
    public class ApiModule : NancyModule
    {
        public ApiModule() : base("/api")
        {
            Post["/RecordSpeedTest"] = _ =>
            {
                var speedTestResult = this.Bind<SpeedTestResultRequest>();
                return RecordSpeedTest(speedTestResult);
            };
        }

        private HttpStatusCode RecordSpeedTest(SpeedTestResultRequest result)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

            try
            {
                var server = result.Server;
                new CreateTestRunCommand().Execute(connectionString,
                    result.Timestamp, result.Ping, result.Download, result.Upload,
                    server.Id, server.Name, server.Host, server.Url, server.Url2,
                    server.Latency, server.D, server.Lat, server.Lon,
                    server.Country, server.Cc, server.Sponsor);

            }
            catch (Exception e)
            {
                throw;
            }

            //response.Headers.Location = new Uri("");
            return HttpStatusCode.Created;
        }
    }
}