using System;
using BroadbandStats.Database.Queries;
using Nancy;

namespace BroadbandStats.Website.Modules.SpeedStats
{
    public class QueryApiModule : NancyModule
    {
        public QueryApiModule(QueryRepository queryRepository) : base("/speed")
        {
            if (queryRepository == null)
            {
                throw new ArgumentNullException(nameof(queryRepository));
            }

            Get["/LastTestResult"] = _ => queryRepository.GetLastTestResult();
            Get["/TodaysTestResults"] = _ => queryRepository.GetTodaysResults();
            Get["/ThisWeeksTestResults"] = _ => queryRepository.GetThisWeeksResults();
            Get["/ThisMonthsTestResults"] = _ => queryRepository.GetThisMonthsResults();
            Get["/ThisYearsTestResults"] = _ => queryRepository.GetThisYearsResults();
        }
    }
}
