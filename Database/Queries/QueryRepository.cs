using System;
using System.Collections.Generic;
using System.Linq;
using BroadbandStats.Database.Models;

namespace BroadbandStats.Database.Queries
{
    public sealed class QueryRepository
    {
        private readonly IConnectionStringProvider connectionStringProvider;

        public QueryRepository(IConnectionStringProvider connectionStringProvider)
        {
            if (connectionStringProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionStringProvider));
            }

            this.connectionStringProvider = connectionStringProvider;
        }

        public TestRunResult GetLastTestResult()
        {
            return new LatestTestRunQuery(connectionStringProvider).Run().SingleOrDefault();
        }

        public IEnumerable<TestRunResult> GetTodaysResults()
        {
            return new TodaysResultsQuery(connectionStringProvider).Run();
        }

        public IEnumerable<TestRunResult> GetThisWeeksResults()
        {
            return new ThisWeeksResultsQuery(connectionStringProvider).Run();
        }

        public IEnumerable<TestRunResult> GetThisMonthsResults()
        {
            return new ThisMonthsResultsQuery(connectionStringProvider).Run();
        }

        public IEnumerable<TestRunResult> GetThisYearsResults()
        {
            return new ThisYearsResultsQuery(connectionStringProvider).Run();
        }
    }
}
