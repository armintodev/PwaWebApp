using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pwa.Application.Contracts.Account.Role;

namespace Pwa.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleApplication _role;
        public RoleController(IRoleApplication role)
        {
            _role = role;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _role.List();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleDto dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _role.Create(dto, cancellationToken);
                if (result.Success)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var role = await _role.Get(id, cancellationToken);
            if (role.Success is false)
                return NotFound();
            return View(role.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRoleDto dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _role.Edit(dto, cancellationToken);
                if (result.Success)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Detail(int id, CancellationToken cancellationToken)
        {
            var role = await _role.Detail(id, cancellationToken);
            if (role.Success is false)
                return NotFound();

            return View(role.Data);
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var role = await _role.Get(id, cancellationToken);
            if (role.Success is false)
                return NotFound();

            var result = await _role.Delete(id, cancellationToken);
            if (result.Success)
                return RedirectToAction("Index");

            return BadRequest(result.Message);
        }
    }
}