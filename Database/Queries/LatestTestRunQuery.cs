using BroadbandSpeedStats.Database.Schema;

namespace BroadbandSpeedStats.Database.Queries
{
    public sealed class LatestTestRunQuery : GetTestRunResultsFromViewQuery
    {
        protected override string ViewName => Views.LatestTestRun.Name;
    }
}
