using Microsoft.AspNetCore.Mvc;
using Pwa.Application.Contracts.Account.Developer;
using Pwa.Application.Contracts.Account.User;
using Pwa.Web.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Pwa.Web.Areas.Admin.Controllers
{
    public class DeveloperController : AdminBaseController
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

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateDeveloperDto dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _developer.Register(dto, cancellationToken);
                if (result.Success)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var developer = await _developer.Get(id);
            if (developer.Success is false)
                return NotFound();

            return View(developer.Data);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDeveloperDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _developer.Edit(dto);
                if (result.Success)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var developer = await _developer.Detail(id);
            if (developer.Success is false)
                return NotFound();

            return View(developer.Data);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthDto dto)
        {
            if (ModelState.IsValid)
            {
                //var result = await _developer.Login(dto);
                //if (result.Success) return View("Index");
                //ModelState.AddModelError("", result.Message);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var developer = await _developer.Get(id);
            if (developer.Success is false)
                return NotFound();

            var result = await _developer.Delete(id);
            if (result.Success)
                return RedirectToAction("Index");

            return BadRequest(result.Message);
        }

        public async Task<IActionResult> Activate(int id)
        {
            var developer = await _developer.Get(id);
            if (developer.Success is false)
                return NotFound();

            await _developer.Activate(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeActivate(int id)
        {
            var developer = await _developer.Get(id);
            if (developer.Success is false)
                return NotFound();

            await _developer.DeActivate(id);
            return RedirectToAction("Index");
        }
    }
}
