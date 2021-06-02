using Microsoft.AspNetCore.Mvc;
using Pwa.Application.Contracts.Account.Developer;
using System.Threading.Tasks;

namespace Pwa.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DeveloperController : Controller
    {
        private readonly IDeveloperApplication _developer;
        public DeveloperController(IDeveloperApplication developer)
        {
            _developer = developer;
        }

        public async Task<IActionResult> Index()
        {
            var developers = await _developer.ListAsync();
            return View(developers);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateDeveloperDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _developer.Register(dto);
                if (result.Success)
                    return View("Index");

                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View();
                }
            }
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
