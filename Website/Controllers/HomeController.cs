using System.Web.Mvc;
using BroadbandSpeedStats.DataAccess;

namespace BroadbandSpeedStats.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Store.LastTestResult);
        }
    }
}
