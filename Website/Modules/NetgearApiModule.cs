using System;
using System.Collections.Generic;
using BroadbandStats.NetgearRouter.Devices;
using BroadbandStats.NetgearRouter.Traffic;
using Nancy;
using Nancy.Extensions;

namespace BroadbandStats.Website.Modules
{
    public sealed class NetgearApiModule : NancyModule
    {
        public NetgearApiModule(AttachedDevicesParser attachedDevicesParser, TrafficStatsParser trafficStatsParser)
            : base("/netgear")
        {
            if (attachedDevicesParser == null)
            {
                throw new ArgumentNullException(nameof(attachedDevicesParser));
            }

            if (trafficStatsParser == null)
            {
                throw new ArgumentNullException(nameof(trafficStatsParser));
            }

            Post["/RecordAttachedDevices"] = _ =>
            {
                var body = Request.Body.AsString();
                var model = attachedDevicesParser.Parse(body);
                return RecordAttachedDevices(model);
            };

            Post["/RecordTrafficStats"] = _ =>
            {
                var body = Request.Body.AsString();
                var model = trafficStatsParser.Parse(body);
                return RecordTrafficStats(model);
            };
        }

        private HttpStatusCode RecordAttachedDevices(IEnumerable<Device> attachedDevices)
        {
            return HttpStatusCode.Created;
        }

        private HttpStatusCode RecordTrafficStats(TrafficStats trafficStats)
        {
            return HttpStatusCode.Created;
        }
    }
}
