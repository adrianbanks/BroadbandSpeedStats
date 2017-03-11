using NetgearRouter.Models;

namespace NetgearRouter.Parsers
{
    public sealed class RouterTrafficParser
    {
        public TrafficStatsModel Parse(string soapResponse)
        {
            return new TrafficStatsModel();
        }
    }
}
