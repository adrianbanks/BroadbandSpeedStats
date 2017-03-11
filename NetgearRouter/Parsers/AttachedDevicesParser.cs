using NetgearRouter.Models;

namespace NetgearRouter.Parsers
{
    public sealed class AttachedDevicesParser
    {
        public AttachedDevicesModel Parse(string soapResponse)
        {
            return new AttachedDevicesModel();
        }
    }
}
