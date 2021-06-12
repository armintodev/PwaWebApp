using Microsoft.AspNetCore.Mvc;

namespace Pwa.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
