﻿using System;
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
            Get["/TodaysTestResults"] = _ => GetTodaysResults();

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
            return new TodaysResultsQuery().Run(connectionString);
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