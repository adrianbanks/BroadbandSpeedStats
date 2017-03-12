using BroadbandStats.Database.Schema;

namespace BroadbandStats.Database.Queries
{
    public sealed class ThisYearsResultsQuery : GetTestRunResultsFromViewQuery
    {
        public ThisYearsResultsQuery(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {}

        protected override string ViewName => Views.ThisYearsTestResults.Name;
    }
}
