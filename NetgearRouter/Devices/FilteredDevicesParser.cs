using System;
using System.Collections.Generic;
using System.Linq;

namespace BroadbandStats.NetgearRouter.Devices
{
    public sealed class FilteredDevicesParser : IDevicesParser
    {
        private readonly IDevicesParser devicesParser;

        public FilteredDevicesParser(IDevicesParser devicesParser)
        {
            if (devicesParser == null)
            {
                throw new ArgumentNullException(nameof(devicesParser));
            }

            this.devicesParser = devicesParser;
        }

        public IEnumerable<Device> Parse(string devicesInformation)
        {
            return devicesParser.Parse(devicesInformation).Where(d => d != Device.Null);
        }
    }
}
