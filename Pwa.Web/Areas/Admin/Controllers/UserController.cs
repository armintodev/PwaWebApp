using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pwa.Application.Contracts.Account.User;

namespace Pwa.Web.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserApplication _user;
        public UserController(IUserApplication user)
        {
            _user = user;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _user.List();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthDto dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _user.Register(dto, cancellationToken);
                if (result.Success)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var user = await _user.Get(id, cancellationToken);
            if (user.Success is false)
                return NotFound();
            return View(user.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserDto dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _user.Edit(dto, cancellationToken);
                if (result.Success)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Detail(int id, CancellationToken cancellationToken)
        {
            var user = await _user.Detail(id, cancellationToken);
            if (user.Success is false)
                return NotFound();

            return View(user.Data);
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var user = await _user.Get(id, cancellationToken);
            if (user.Success is false)
                return NotFound();

            var result = await _user.Delete(id, cancellationToken);
            if (result.Success)
                return RedirectToAction("Index");

            return BadRequest(result.Message);
        }

        public async Task<IActionResult> Activate(int id, CancellationToken cancellationToken)
        {
            var user = await _user.Get(id, cancellationToken);
            if (user.Success is false)
                return NotFound();

            await _user.Activate(id, cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeActivate(int id, CancellationToken cancellationToken)
        {
            var user = await _user.Get(id, cancellationToken);
            if (user.Success is false)
                return NotFound();

            await _user.DeActivate(id, cancellationToken);
            return RedirectToAction("Index");
        }
    }
}
