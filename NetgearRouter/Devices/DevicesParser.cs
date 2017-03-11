using System;
using System.Collections.Generic;
using System.Linq;

namespace BroadbandStats.NetgearRouter.Devices
{
    public sealed class DevicesParser : IDevicesParser
    {
        // devices information is in the form:
        //      count@device information@device information@device information... @
        //
        // e.g. 3@device1@device2@device3@

        private readonly IDeviceParser deviceParser;

        public DevicesParser(IDeviceParser deviceParser)
        {
            if (deviceParser == null)
            {
                throw new ArgumentNullException(nameof(deviceParser));
            }

            this.deviceParser = deviceParser;
        }

        public IEnumerable<Device> Parse(string devicesInformation)
        {
            return ParseInner(devicesInformation).Where(d => d != Device.Null);
        }

        private IEnumerable<Device> ParseInner(string devicesInformation)
        {
            if (string.IsNullOrWhiteSpace(devicesInformation))
            {
                yield break;
            }

            var parts = devicesInformation.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
            {
                yield break;
            }

            int deviceCount;

            if (!int.TryParse(parts[0], out deviceCount)
                || deviceCount != parts.Length - 1)
            {
                yield break;
            }

            foreach (var deviceInformation in parts.Skip(1))
            {
                yield return deviceParser.Parse(deviceInformation);
            }
        }
    }
}
