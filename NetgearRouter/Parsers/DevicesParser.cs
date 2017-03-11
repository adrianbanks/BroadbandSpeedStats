using System;
using System.Collections.Generic;
using System.Linq;
using BroadbandStats.NetgearRouter.Models;

namespace BroadbandStats.NetgearRouter.Parsers
{
    public sealed class DevicesParser
    {
        // devices information is in the form:
        //      count@device information@device information@device information... @
        //
        // e.g. 3@device1@device2@device3@

        public IEnumerable<Device> Parse(string devicesInformation)
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

            var deviceParser = new DeviceParser();

            foreach (var deviceInformation in parts.Skip(1))
            {
                yield return deviceParser.Parse(deviceInformation);
            }
        }
    }
}
