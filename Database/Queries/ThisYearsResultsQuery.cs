using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Queries
{
    public sealed class ThisYearsResultsQuery : GetTestRunResultsFromViewQuery
    {
        protected override string ViewName => Views.ThisYearsTestResults.Name;
    }
}
