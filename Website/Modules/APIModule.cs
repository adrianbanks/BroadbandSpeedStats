using System;
using System.Configuration;
using BroadbandSpeedStats.Database.Commands;
using BroadbandSpeedStats.Database.Models;
using BroadbandSpeedStats.Database.Queries;
using BroadbandSpeedTests.Website.Models;
using Nancy;
using Nancy.ModelBinding;

namespace BroadbandSpeedTests.Website.Modules
{
    public class ApiModule : NancyModule
    {
        public ApiModule() : base("/api")
        {
            Get["/LastTestResult"] = _ => GetLastTestResult();
            Get["/TodaysResults"] = _ => GetTodaysResults();

            Post["/RecordSpeedTest"] = _ =>
            {
                var speedTestResult = this.Bind<SpeedTestResultRequest>();
                return RecordSpeedTest(speedTestResult);
            };
        }

        private TestRunResult GetLastTestResult()
        {
            System.Threading.Thread.Sleep(1500);
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            return new LatestTestRunQuery().Run(connectionString);
        }

        private object GetTodaysResults()
        {
            System.Threading.Thread.Sleep(1500);
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

            var today = DateTime.Today;
            return new[]
                {
                    new TestRunResult(today, 55, 0, 0),
                    new TestRunResult(today.AddHours(1), 55, 0, 0),
                    new TestRunResult(today.AddHours(2), 51, 0, 0),
                    new TestRunResult(today.AddHours(3), 22, 0, 0),
                    new TestRunResult(today.AddHours(4), 15, 0, 0),
                    new TestRunResult(today.AddHours(5), 27, 0, 0),
                    new TestRunResult(today.AddHours(6), 22, 0, 0),
                    new TestRunResult(today.AddHours(7), 19, 0, 0),
                    new TestRunResult(today.AddHours(8), 50, 0, 0),
                    new TestRunResult(today.AddHours(9), 67, 0, 0),
                    new TestRunResult(today.AddHours(10), 55, 0, 0),
                    new TestRunResult(today.AddHours(11), 52, 0, 0),
                    new TestRunResult(today.AddHours(12), 44, 0, 0),
                    new TestRunResult(today.AddHours(13), 42, 0, 0),
                    new TestRunResult(today.AddHours(14), 34, 0, 0),
                    new TestRunResult(today.AddHours(15), 17, 0, 0),
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