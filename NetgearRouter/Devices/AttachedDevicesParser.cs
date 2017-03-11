using System;
using System.Collections.Generic;
using System.Linq;

namespace BroadbandStats.NetgearRouter.Devices
{
    public sealed class AttachedDevicesParser
    {
        private readonly IDevicesParser devicesParser;
        private readonly IDeviceInformationExtractor deviceInformationExtractor;

        public AttachedDevicesParser(IDevicesParser devicesParser, IDeviceInformationExtractor deviceInformationExtractor)
        {
            if (devicesParser == null)
            {
                throw new ArgumentNullException(nameof(devicesParser));
            }

            if (deviceInformationExtractor == null)
            {
                throw new ArgumentNullException(nameof(deviceInformationExtractor));
            }

            this.devicesParser = devicesParser;
            this.deviceInformationExtractor = deviceInformationExtractor;
        }

        public IEnumerable<Device> Parse(string soapResponse)
        {
            if (string.IsNullOrWhiteSpace(soapResponse))
            {
                return Enumerable.Empty<Device>();
            }

            var deviceInformation = deviceInformationExtractor.ExtractDeviceInformation(soapResponse);
            return devicesParser.Parse(deviceInformation);
        }
    }
}
