using System.Web.Mvc;
using BroadbandSpeedStats.Web.DataAccess;

namespace BroadbandSpeedStats.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Store.LastTestResult);
        }
    }
}
