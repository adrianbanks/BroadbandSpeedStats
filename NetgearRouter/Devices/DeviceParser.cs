using System;

namespace BroadbandStats.NetgearRouter.Devices
{
    public class DeviceParser
    {
        // device information is in the form:
        //      id;ip address;name;mac address;connection type

        public Device Parse(string deviceInformation)
        {
            if (string.IsNullOrWhiteSpace(deviceInformation))
            {
                return Device.Null;
            }

            var parts = deviceInformation.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 5)
            {
                return Device.Null;
            }

            var ipAddress = parts[1];
            var name = parts[2];
            var macAddress = parts[3];
            var connectionType = parts[4];
            return new Device(name, ipAddress, macAddress, connectionType);
        }
    }
}
