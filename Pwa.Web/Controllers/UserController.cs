using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pwa.Application.Contracts.Account.User;

namespace Pwa.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApplication _user;
        public UserController(IUserApplication user)
        {
            _user = user;
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AuthDto dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                return View("VerifyAccount");
            }
            return View(dto);
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthDto dto, CancellationToken cancellationToken)
        {
            return View();
        }

        public async Task<IActionResult> VerifyAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyAccount(CancellationToken cancellationToken)
        {
            return View();
        }
    }
}
