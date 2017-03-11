using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Queries
{
    public sealed class LatestTestRunQuery : GetTestRunResultsFromViewQuery
    {
        protected override string ViewName => Views.LatestTestRun.Name;
    }
}
