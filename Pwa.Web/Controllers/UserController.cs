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
                var result = await _user.Register(dto, cancellationToken);
                if (result.Success)
                    return RedirectToAction("VerifyAccount", new SmsVerifyDto { PhoneNumber = dto.PhoneNumber, RememberMe = dto.RememberMe });

                ModelState.AddModelError("", result.Message);
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
            if (ModelState.IsValid)
            {
                var result = await _user.Login(dto, cancellationToken);
                if (result.Success)
                    return RedirectToAction("VerifyAccount", new SmsVerifyDto { PhoneNumber = dto.PhoneNumber, RememberMe = dto.RememberMe });

                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> VerifyAccount(SmsVerifyDto dto)
        {
            if (dto.PhoneNumber is null) return NotFound();
            var result = await _user.SendCode(dto.PhoneNumber, HttpContext.RequestAborted);
            if (result.Success)
                return View(dto);

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyAccount(SmsVerifyDto dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _user.VerifyAccountBySms(dto, cancellationToken);
                if (result.Success)
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }
    }
}
