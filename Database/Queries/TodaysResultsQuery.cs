using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Queries
{
    public sealed class TodaysResultsQuery : GetTestRunResultsFromViewQuery
    {
        public TodaysResultsQuery(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {}

        protected override string ViewName => Views.TodaysTestResults.Name;
    }
}
