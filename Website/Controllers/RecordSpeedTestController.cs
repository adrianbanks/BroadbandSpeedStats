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
                new CreateTestRunCommand().Execute(connectionString, result.Timestamp, result.Ping, result.Download, result.Upload);

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
