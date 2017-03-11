using BroadbandStats.NetgearRouter.Models;

namespace BroadbandStats.NetgearRouter.Parsers
{
    public sealed class RouterTrafficParser
    {
        public TrafficStatsModel Parse(string soapResponse)
        {
            return new TrafficStatsModel();
        }
    }
}
