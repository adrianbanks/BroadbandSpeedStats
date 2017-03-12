using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Queries
{
    public sealed class ThisWeeksResultsQuery : GetTestRunResultsFromViewQuery
    {
        public ThisWeeksResultsQuery(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {}

        protected override string ViewName => Views.ThisWeeksTestResults.Name;
    }
}
