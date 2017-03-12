using System;
using BroadbandStats.Database.Commands;
using BroadbandStats.NetgearRouter.Traffic;
using Nancy;
using Nancy.Extensions;

namespace BroadbandStats.Website.Modules.Netgear
{
    public sealed class TrafficStatsApiModule : NancyModule
    {
        public TrafficStatsApiModule(TrafficStatsParser trafficStatsParser, CreateTrafficStatsCommand createTrafficStatsCommand) : base("/netgear")
        {
            if (trafficStatsParser == null)
            {
                throw new ArgumentNullException(nameof(trafficStatsParser));
            }

            Post["/RecordTrafficStats"] = _ =>
            {
                var requestBody = Request.Body.AsString();
                var trafficStats = trafficStatsParser.Parse(requestBody);
                return RecordTrafficStats(createTrafficStatsCommand, trafficStats);
            };
        }

        private HttpStatusCode RecordTrafficStats(CreateTrafficStatsCommand command, TrafficStats trafficStats)
        {
            var timestamp = DateTime.UtcNow;
            command.Execute(timestamp, trafficStats.Download, trafficStats.Upload);
            return HttpStatusCode.Created;
        }
    }
}
