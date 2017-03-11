using System.Configuration;
using Nancy;
using Nancy.Extensions;
using NetgearRouter.Models;
using NetgearRouter.Parsers;

namespace BroadbandSpeedTests.Website.Modules
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
                var body = Request.Body.AsString();
                var model = new RouterTrafficParser().Parse(body);
                return RecordRouterTraffic(model);
            };
        }

        private HttpStatusCode RecordRouterDevices(AttachedDevicesModel model)
        {
            return HttpStatusCode.Created;
        }

        private HttpStatusCode RecordRouterTraffic(TrafficStatsModel model)
        {
            return HttpStatusCode.Created;
        }
    }
}
