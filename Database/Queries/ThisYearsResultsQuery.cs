using BroadbandSpeedStats.Database.Schema;

namespace BroadbandSpeedStats.Database.Queries
{
    public sealed class ThisYearsResultsQuery : GetTestRunResultsFromViewQuery
    {
        protected override string ViewName => Views.ThisYearsTestResults.Name;
    }
}
