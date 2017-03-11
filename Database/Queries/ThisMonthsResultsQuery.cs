using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Queries
{
    public sealed class ThisMonthsResultsQuery : GetTestRunResultsFromViewQuery
    {
        protected override string ViewName => Views.ThisMonthsTestResults.Name;
    }
}
