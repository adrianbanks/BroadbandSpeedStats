using System;
using System.Collections.Generic;
using BroadbandStats.NetgearRouter.Devices;
using Nancy;
using Nancy.Extensions;

namespace BroadbandStats.Website.Modules.Netgear
{
    public sealed class AttachedDevicesApiModule : NancyModule
    {
        public AttachedDevicesApiModule(AttachedDevicesParser attachedDevicesParser) : base("/netgear")
        {
            if (attachedDevicesParser == null)
            {
                throw new ArgumentNullException(nameof(attachedDevicesParser));
            }

            Post["/RecordAttachedDevices"] = _ =>
            {
                var requestBody = Request.Body.AsString();
                var attachedDevices = attachedDevicesParser.Parse(requestBody);
                return RecordAttachedDevices(attachedDevices);
            };
        }

        private HttpStatusCode RecordAttachedDevices(IEnumerable<Device> attachedDevices)
        {
            return HttpStatusCode.Created;
        }
    }
}
