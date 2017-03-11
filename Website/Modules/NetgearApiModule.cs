using System;
using System.Collections.Generic;
using BroadbandStats.NetgearRouter.Devices;
using Nancy;
using Nancy.Extensions;

namespace BroadbandStats.Website.Modules
{
    public sealed class NetgearApiModule : NancyModule
    {
        public NetgearApiModule(AttachedDevicesParser attachedDevicesParser) : base("/netgear")
        {
            if (attachedDevicesParser == null)
            {
                throw new ArgumentNullException(nameof(attachedDevicesParser));
            }

            Post["/RecordAttachedDevices"] = _ =>
            {
                var body = Request.Body.AsString();
                var model = attachedDevicesParser.Parse(body);
                return RecordAttachedDevices(model);
            };

            Post["/RecordTrafficStats"] = _ =>
            {
//                var body = Request.Body.AsString();
//                var model = new RouterTrafficParser().Parse(body);
                return RecordTrafficStats();
            };
        }

        private HttpStatusCode RecordAttachedDevices(IEnumerable<Device> attachedDevices)
        {
            return HttpStatusCode.Created;
        }

        private HttpStatusCode RecordTrafficStats()
        {
            return HttpStatusCode.Created;
        }
    }
}
