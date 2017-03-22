using System;
using System.Collections.Generic;
using System.Linq;
using BroadbandStats.Database.Commands;
using BroadbandStats.Database.Queries;
using BroadbandStats.NetgearRouter.Devices;
using Nancy;
using Nancy.Extensions;

namespace BroadbandStats.Website.Modules.Netgear
{
    public sealed class AttachedDevicesApiModule : NancyModule
    {
        public AttachedDevicesApiModule(AttachedDevicesParser attachedDevicesParser,
            GetDeviceIdQuery getDeviceQuery,
            CreateDeviceCommand createDeviceCommand,
            CreateAttachedDevicesSnaphotCommand createAttachedDevicesSnaphotCommand,
            CreateDeviceSnapshotEntryCommand createDeviceSnapshotEntryCommand)
            : base("/netgear")
        {
            if (getDeviceQuery == null)
            {
                throw new ArgumentNullException(nameof(getDeviceQuery));
            }

            if (createDeviceCommand == null)
            {
                throw new ArgumentNullException(nameof(createDeviceCommand));
            }

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
                return RecordAttachedDevices(getDeviceQuery,
                    createDeviceCommand,
                    createAttachedDevicesSnaphotCommand,
                    createDeviceSnapshotEntryCommand,
                    attachedDevices.ToList());
            };
        }

        private HttpStatusCode RecordAttachedDevices(GetDeviceIdQuery getDeviceQuery,
            CreateDeviceCommand createDeviceCommand,
            CreateAttachedDevicesSnaphotCommand snapshotCommand,
            CreateDeviceSnapshotEntryCommand devicesCommand,
            ICollection<Device> attachedDevices)
        {
            var timestamp = DateTime.UtcNow;
            int snapshotIdentity = snapshotCommand.Execute(timestamp, attachedDevices.Count);

            foreach (var device in attachedDevices)
            {
                var deviceId = GetOrCreateDeviceId(getDeviceQuery, createDeviceCommand, device.Name, device.MacAddress);
                devicesCommand.Execute(snapshotIdentity, deviceId, device.IpAddress, device.ConnectionType);
            }

            return HttpStatusCode.Created;
        }

        private int GetOrCreateDeviceId(GetDeviceIdQuery getDeviceQuery, CreateDeviceCommand createDeviceCommand, string name, string macAddress)
        {
            var deviceId = getDeviceQuery.Run(name, macAddress);
            return deviceId != 0 ? deviceId : createDeviceCommand.Execute(name, macAddress);
        }
    }
}
