using Microsoft.AspNetCore.Mvc;

namespace Zaren.Web.Controllers
{
    public class FlightController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
