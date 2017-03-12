using System;
using System.Linq;
using BroadbandStats.Database.Models;
using BroadbandStats.Database.Queries;
using Nancy;

namespace BroadbandStats.Website.Modules.SpeedStats
{
    public class QueryApiModule : NancyModule
    {
        public QueryApiModule(ConnectionStringProvider connectionStringProvider) : base("/speed")
        {
            if (connectionStringProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionStringProvider));
            }

            var connectionString = connectionStringProvider.GetConnectionString();

            Get["/LastTestResult"] = _ => GetLastTestResult(connectionString);
            Get["/TodaysTestResults"] = _ => GetTodaysResults(connectionString);
            Get["/ThisWeeksTestResults"] = _ => GetThisWeeksResults(connectionString);
            Get["/ThisMonthsTestResults"] = _ => GetThisMonthsResults(connectionString);
            Get["/ThisYearsTestResults"] = _ => GetThisYearsResults(connectionString);
        }

        private TestRunResult GetLastTestResult(string connectionString)
        {
            return new LatestTestRunQuery().Run(connectionString).SingleOrDefault();
        }

        private object GetTodaysResults(string connectionString)
        {
            return new TodaysResultsQuery().Run(connectionString);
        }

        private object GetThisWeeksResults(string connectionString)
        {
            return new ThisWeeksResultsQuery().Run(connectionString);
        }

        private object GetThisMonthsResults(string connectionString)
        {
            return new ThisMonthsResultsQuery().Run(connectionString);
        }

        private object GetThisYearsResults(string connectionString)
        {
            return new ThisYearsResultsQuery().Run(connectionString);
        }
   }
}