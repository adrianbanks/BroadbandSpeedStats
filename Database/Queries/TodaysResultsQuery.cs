using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Queries
{
    public sealed class TodaysResultsQuery : GetTestRunResultsFromViewQuery
    {
        protected override string ViewName => Views.TodaysTestResults.Name;
    }
}
