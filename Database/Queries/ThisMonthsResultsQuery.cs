using BroadbandSpeedStats.Database.Schema;

namespace BroadbandSpeedStats.Database.Queries
{
    public sealed class ThisMonthsResultsQuery : GetTestRunResultsFromViewQuery
    {
        protected override string ViewName => Views.ThisMonthsTestResults.Name;
    }
}
