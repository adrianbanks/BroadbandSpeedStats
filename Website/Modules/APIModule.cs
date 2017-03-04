using System.Configuration;
using System.Linq;
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
        private readonly string connectionString;

        public ApiModule() : base("/api")
        {
            connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

            Get["/LastTestResult"] = _ => GetLastTestResult();
            Get["/TodaysTestResults"] = _ => GetTodaysResults();
            Get["/ThisWeeksTestResults"] = _ => GetThisWeeksResults();
            Get["/ThisMonthsTestResults"] = _ => GetThisMonthsResults();

            Post["/RecordSpeedTest"] = _ =>
            {
                var speedTestResult = this.Bind<SpeedTestResultRequest>();
                return RecordSpeedTest(speedTestResult);
            };
        }

        private TestRunResult GetLastTestResult()
        {
            return new LatestTestRunQuery().Run(connectionString).SingleOrDefault();
        }

        private object GetTodaysResults()
        {
            return new TodaysResultsQuery().Run(connectionString);
        }

        private object GetThisWeeksResults()
        {
            return new ThisWeeksResultsQuery().Run(connectionString);
        }

        private object GetThisMonthsResults()
        {
            return new ThisMonthsResultsQuery().Run(connectionString);
        }

        private HttpStatusCode RecordSpeedTest(SpeedTestResultRequest result)
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