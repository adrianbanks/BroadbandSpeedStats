using Nancy;

namespace BroadbandStats.Website.Modules.Devices
{
    public class DevicesModule : NancyModule
    {
        public DevicesModule() : base("/devices")
        {
            Get["/"] = parameters => View["devices/current.html"];
        }
    }
}
