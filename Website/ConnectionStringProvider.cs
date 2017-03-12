using System.Configuration;

namespace BroadbandStats.Website
{
    public sealed class ConnectionStringProvider
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }
    }
}
