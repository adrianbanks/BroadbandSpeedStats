using System.Configuration;
using System.Web.Mvc;
using BroadbandSpeedStats.Database.Queries;

namespace BroadbandSpeedStats.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            var latestTestResult = new LatestTestRunQuery().Run(connectionString);
            return View(latestTestResult);
        }
    }
}
