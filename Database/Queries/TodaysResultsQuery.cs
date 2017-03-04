using BroadbandSpeedStats.Database.Schema;

namespace BroadbandSpeedStats.Database.Queries
{
    public sealed class TodaysResultsQuery : GetTestRunResultsFromViewQuery
    {
        protected override string ViewName => Views.TodaysTestResults.Name;
    }
}
