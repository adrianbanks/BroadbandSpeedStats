using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BroadbandSpeedStats.Database.Commands;
using BroadbandSpeedStats.Web.Models;

namespace BroadbandSpeedStats.Web.Controllers
{
    public class RecordSpeedTestController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(SpeedTestResultRequest result)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            try
            {
                var server = result.Server;
                new CreateTestRunCommand().Execute(connectionString,
                    result.Timestamp, result.Ping, result.Download, result.Upload,
                    server.Id, server.Name, server.Host, server.Url, server.Url2,
                    server.Latency, server.D, server.Lat, server.Lon,
                    server.Country, server.Cc, server.Sponsor);

            }
            catch (Exception e)
            {
                throw;
            }

            var response = new HttpResponseMessage(HttpStatusCode.Created);
            //response.Headers.Location = new Uri("");
            return response;
        }
    }
}
