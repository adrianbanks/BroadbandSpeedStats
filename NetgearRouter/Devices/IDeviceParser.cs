namespace BroadbandStats.NetgearRouter.Devices
{
    public interface IDeviceParser
    {
        Device Parse(string deviceInformation);
    }
}
