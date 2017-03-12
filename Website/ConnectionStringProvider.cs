using System.Configuration;
using BroadbandStats.Database;

namespace BroadbandStats.Website
{
    public sealed class ConnectionStringProvider : IConnectionStringProvider
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }
    }
}
