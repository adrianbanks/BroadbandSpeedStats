using BroadbandSpeedStats.Database.Schema;

namespace BroadbandSpeedStats.Database.Queries
{
    public sealed class ThisWeeksResultsQuery : GetTestRunResultsFromViewQuery
    {
        protected override string ViewName => Views.ThisWeeksTestResults.Name;
    }
}
