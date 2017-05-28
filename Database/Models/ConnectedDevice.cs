namespace BroadbandStats.Database.Models
{
    public class ConnectedDevice
    {
        public int DeviceId { get; }
        public string DeviceName { get; }
        public string MacAddress { get; }
        public string IpAddress { get; }
        public string Description { get; }
        public string ConnectionType { get; }

        public ConnectedDevice(int deviceId, string deviceName, string macAddress, string ipAddress, string description, string connectionType)
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            MacAddress = macAddress;
            IpAddress = ipAddress;
            Description = description;
            ConnectionType = connectionType;
        }
    }
}
