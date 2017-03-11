using BroadbandStats.NetgearRouter.Models;

namespace BroadbandStats.NetgearRouter.Parsers
{
    public sealed class AttachedDevicesParser
    {
        public AttachedDevicesModel Parse(string soapResponse)
        {
            return new AttachedDevicesModel();
        }
    }
}
