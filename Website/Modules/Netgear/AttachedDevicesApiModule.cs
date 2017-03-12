using System;
using System.Collections.Generic;
using System.Linq;
using BroadbandStats.Database.Commands;
using BroadbandStats.NetgearRouter.Devices;
using Nancy;
using Nancy.Extensions;

namespace BroadbandStats.Website.Modules.Netgear
{
    public sealed class AttachedDevicesApiModule : NancyModule
    {
        public AttachedDevicesApiModule(AttachedDevicesParser attachedDevicesParser,
            CreateAttachedDevicesSnaphotCommand createAttachedDevicesSnaphotCommand,
            CreateDeviceSnapshotEntryCommand createDeviceSnapshotEntryCommand)
            : base("/netgear")
        {
            if (attachedDevicesParser == null)
            {
                throw new ArgumentNullException(nameof(attachedDevicesParser));
            }

            if (createAttachedDevicesSnaphotCommand == null)
            {
                throw new ArgumentNullException(nameof(createAttachedDevicesSnaphotCommand));
            }

            if (createDeviceSnapshotEntryCommand == null)
            {
                throw new ArgumentNullException(nameof(createDeviceSnapshotEntryCommand));
            }

            Post["/RecordAttachedDevices"] = _ =>
            {
                var requestBody = Request.Body.AsString();
                var attachedDevices = attachedDevicesParser.Parse(requestBody);
                return RecordAttachedDevices(createAttachedDevicesSnaphotCommand, createDeviceSnapshotEntryCommand, attachedDevices.ToList());
            };
        }

        private HttpStatusCode RecordAttachedDevices(CreateAttachedDevicesSnaphotCommand snapshotCommand,
            CreateDeviceSnapshotEntryCommand devicesCommand,
            ICollection<Device> attachedDevices)
        {
            var timestamp = DateTime.UtcNow;
            int snapshotIdentity = snapshotCommand.Execute(timestamp, attachedDevices.Count);

            foreach (var device in attachedDevices)
            {
                devicesCommand.Execute(snapshotIdentity, device.Name, device.IpAddress, device.MacAddress, device.ConnectionType);
            }

            return HttpStatusCode.Created;
        }
    }
}
