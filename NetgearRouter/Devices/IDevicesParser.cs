using System.Collections.Generic;

namespace BroadbandStats.NetgearRouter.Devices
{
    public interface IDevicesParser
    {
        IEnumerable<Device> Parse(string devicesInformation);
    }
}
