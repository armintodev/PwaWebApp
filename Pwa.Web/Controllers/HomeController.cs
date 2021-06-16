using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebFramework.Utilities.Sms;

namespace Pwa.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISmsService _sms;
        public HomeController(ISmsService sms)
        {
            _sms = sms;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InviteFriend(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return View();
            }
            await _sms.Send(phoneNumber, "شما به داریا وب اپ دعوت شده اید!");
            return RedirectToAction("Index");
        }
    }
}
