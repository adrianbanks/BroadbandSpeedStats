using System.Collections.Generic;
using System.Configuration;
using BroadbandStats.NetgearRouter.Devices;
using Nancy;
using Nancy.Extensions;

namespace BroadbandStats.Website.Modules
{
    public sealed class NetgearApiModule : NancyModule
    {
        private readonly string connectionString;

        public NetgearApiModule() : base("/netgear")
        {
            connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

            Post["/RecordRouterDevices"] = _ =>
            {
                var body = Request.Body.AsString();
                var model = new AttachedDevicesParser().Parse(body);
                return RecordRouterDevices(model);
            };

            Post["/RecordRouterTraffic"] = _ =>
            {
//                var body = Request.Body.AsString();
//                var model = new RouterTrafficParser().Parse(body);
                return RecordRouterTraffic();
            };
        }

        private HttpStatusCode RecordRouterDevices(IEnumerable<Device> attachedDevices)
        {
            return HttpStatusCode.Created;
        }

        private HttpStatusCode RecordRouterTraffic()
        {
            return HttpStatusCode.Created;
        }
    }
}
