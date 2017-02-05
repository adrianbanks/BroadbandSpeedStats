using System.Net;
using System.Net.Http;
using System.Web.Http;
using BroadbandSpeedStats.DataAccess;
using BroadbandSpeedStats.Models;

namespace BroadbandSpeedStats.Controllers
{
    public class RecordSpeedTestController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(SpeedTestResultRequest speedTestResult)
        {
            Store.LastTestResult = speedTestResult;
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            //response.Headers.Location = new Uri("");
            return response;
        }
    }
}
