using System;
using System.Collections.Generic;
using BroadbandStats.NetgearRouter.Devices;
using Nancy;
using Nancy.Extensions;

namespace BroadbandStats.Website.Modules
{
    public sealed class NetgearApiModule : NancyModule
    {
        private readonly AttachedDevicesParser attachedDevicesParser;

        public NetgearApiModule(AttachedDevicesParser attachedDevicesParser) : base("/netgear")
        {
            if (attachedDevicesParser == null)
            {
                throw new ArgumentNullException(nameof(attachedDevicesParser));
            }

            this.attachedDevicesParser = attachedDevicesParser;

            Post["/RecordRouterDevices"] = _ =>
            {
                var body = Request.Body.AsString();
                var model = attachedDevicesParser.Parse(body);
                return RecordRouterDevices(model);
            };

            Post["/RecordRouterTraffic"] = _ =>
            {
//                var body = Request.Body.AsString();
//                var model = new RouterTrafficParser().Parse(body);
                return RecordRouterTraffic();
            };
        }

        private HttpStatusCode RecordRouterDevices(IEnumerable<Device> attachedDevices)
        {
            return HttpStatusCode.Created;
        }

        private HttpStatusCode RecordRouterTraffic()
        {
            return HttpStatusCode.Created;
        }
    }
}
