using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Queries
{
    public sealed class ThisMonthsResultsQuery : GetTestRunResultsFromViewQuery
    {
        public ThisMonthsResultsQuery(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {}

        protected override string ViewName => Views.ThisMonthsTestResults.Name;
    }
}
