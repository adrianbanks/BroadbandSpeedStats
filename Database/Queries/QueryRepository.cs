﻿using System;
using System.Collections.Generic;
using System.Linq;
using BroadbandStats.Database.Models;

namespace BroadbandStats.Database.Queries
{
    public sealed class QueryRepository
    {
        private readonly CurrentlyAttachedDevicesQuery currentlyAttachedDevicesQuery;
        private readonly LatestTestRunQuery latestTestRunQuery;
        private readonly TodaysResultsQuery todaysResultsQuery;
        private readonly ThisWeeksResultsQuery thisWeeksResultsQuery;
        private readonly ThisMonthsResultsQuery thisMonthsResultsQuery;
        private readonly ThisYearsResultsQuery thisYearsResultsQuery;

        public QueryRepository(CurrentlyAttachedDevicesQuery currentlyAttachedDevicesQuery,
            LatestTestRunQuery latestTestRunQuery,
            TodaysResultsQuery todaysResultsQuery,
            ThisWeeksResultsQuery thisWeeksResultsQuery,
            ThisMonthsResultsQuery thisMonthsResultsQuery,
            ThisYearsResultsQuery thisYearsResultsQuery)
        {
            if (currentlyAttachedDevicesQuery == null)
            {
                throw new ArgumentNullException(nameof(currentlyAttachedDevicesQuery));
            }

            if (latestTestRunQuery == null)
            {
                throw new ArgumentNullException(nameof(latestTestRunQuery));
            }

            if (todaysResultsQuery == null)
            {
                throw new ArgumentNullException(nameof(todaysResultsQuery));
            }

            if (thisWeeksResultsQuery == null)
            {
                throw new ArgumentNullException(nameof(thisWeeksResultsQuery));
            }

            if (thisMonthsResultsQuery == null)
            {
                throw new ArgumentNullException(nameof(thisMonthsResultsQuery));
            }

            if (thisYearsResultsQuery == null)
            {
                throw new ArgumentNullException(nameof(thisYearsResultsQuery));
            }

            this.currentlyAttachedDevicesQuery = currentlyAttachedDevicesQuery;
            this.latestTestRunQuery = latestTestRunQuery;
            this.todaysResultsQuery = todaysResultsQuery;
            this.thisWeeksResultsQuery = thisWeeksResultsQuery;
            this.thisMonthsResultsQuery = thisMonthsResultsQuery;
            this.thisYearsResultsQuery = thisYearsResultsQuery;
        }

        public IEnumerable<ConnectedDevice> GetCurrentlyAttachedDevices()
        {
            return currentlyAttachedDevicesQuery.Run();
        }

        public TestRunResult GetLastTestResult()
        {
            return latestTestRunQuery.Run().SingleOrDefault();
        }

        public IEnumerable<TestRunResult> GetTodaysResults()
        {
            return todaysResultsQuery.Run();
        }

        public IEnumerable<TestRunResult> GetThisWeeksResults()
        {
            return thisWeeksResultsQuery.Run();
        }

        public IEnumerable<TestRunResult> GetThisMonthsResults()
        {
            return thisMonthsResultsQuery.Run();
        }

        public IEnumerable<TestRunResult> GetThisYearsResults()
        {
            return thisYearsResultsQuery.Run();
        }
    }
}
