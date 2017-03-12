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

            Get["/LastTestResult"] = _ => GetLastTestResult(connectionStringProvider);
            Get["/TodaysTestResults"] = _ => GetTodaysResults(connectionStringProvider);
            Get["/ThisWeeksTestResults"] = _ => GetThisWeeksResults(connectionStringProvider);
            Get["/ThisMonthsTestResults"] = _ => GetThisMonthsResults(connectionStringProvider);
            Get["/ThisYearsTestResults"] = _ => GetThisYearsResults(connectionStringProvider);
        }

        private TestRunResult GetLastTestResult(ConnectionStringProvider connectionStringProvider)
        {
            return new LatestTestRunQuery(connectionStringProvider).Run().SingleOrDefault();
        }

        private object GetTodaysResults(ConnectionStringProvider connectionStringProvider)
        {
            return new TodaysResultsQuery(connectionStringProvider).Run();
        }

        private object GetThisWeeksResults(ConnectionStringProvider connectionStringProvider)
        {
            return new ThisWeeksResultsQuery(connectionStringProvider).Run();
        }

        private object GetThisMonthsResults(ConnectionStringProvider connectionStringProvider)
        {
            return new ThisMonthsResultsQuery(connectionStringProvider).Run();
        }

        private object GetThisYearsResults(ConnectionStringProvider connectionStringProvider)
        {
            return new ThisYearsResultsQuery(connectionStringProvider).Run();
        }
   }
}