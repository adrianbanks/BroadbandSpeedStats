using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Queries
{
    public sealed class LatestTestRunQuery : GetTestRunResultsFromViewQuery
    {
        public LatestTestRunQuery(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {}

        protected override string ViewName => Views.LatestTestRun.Name;
    }
}
