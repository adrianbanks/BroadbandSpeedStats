using System;
using BroadbandStats.NetgearRouter.Traffic;
using Nancy;
using Nancy.Extensions;

namespace BroadbandStats.Website.Modules.Netgear
{
    public sealed class TrafficStatsApiModule : NancyModule
    {
        public TrafficStatsApiModule(TrafficStatsParser trafficStatsParser) : base("/netgear")
        {
            if (trafficStatsParser == null)
            {
                throw new ArgumentNullException(nameof(trafficStatsParser));
            }

            Post["/RecordTrafficStats"] = _ =>
            {
                var requestBody = Request.Body.AsString();
                var trafficStats = trafficStatsParser.Parse(requestBody);
                return RecordTrafficStats(trafficStats);
            };
        }

        private HttpStatusCode RecordTrafficStats(TrafficStats trafficStats)
        {
            return HttpStatusCode.Created;
        }
    }
}
