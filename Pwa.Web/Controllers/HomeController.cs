using Microsoft.AspNetCore.Mvc;

namespace Pwa.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
