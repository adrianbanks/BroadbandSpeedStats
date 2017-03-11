using System;

namespace BroadbandStats.NetgearRouter.Devices
{
    public sealed class Device
    {
        public static readonly Device Null = new Device(string.Empty, string.Empty, string.Empty, string.Empty);

        public string Name { get; }
        public string IpAddress { get; }
        public string MacAddress { get; }
        public string ConnectionType { get; }

        public Device(string name, string ipAddress, string macAddress, string connectionType)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (ipAddress == null)
            {
                throw new ArgumentNullException(nameof(ipAddress));
            }

            if (macAddress == null)
            {
                throw new ArgumentNullException(nameof(macAddress));
            }

            if (connectionType == null)
            {
                throw new ArgumentNullException(nameof(connectionType));
            }

            Name = name;
            IpAddress = ipAddress;
            MacAddress = macAddress;
            ConnectionType = connectionType;
        }
    }
}
