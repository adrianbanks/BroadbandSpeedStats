using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Queries
{
    public sealed class ThisWeeksResultsQuery : GetTestRunResultsFromViewQuery
    {
        protected override string ViewName => Views.ThisWeeksTestResults.Name;
    }
}
