using Microsoft.AspNetCore.Mvc;
using Pwa.Application.Contracts.Product.Comment;
using Pwa.Query.Contracts.WebApp;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Utilities.Sms;

namespace Pwa.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebAppQuery _webApp;
        private readonly ICommentApplication _comment;
        private readonly ISmsService _sms;
        public HomeController(ISmsService sms, IWebAppQuery webApp, ICommentApplication comment)
        {
            _sms = sms;
            _webApp = webApp;
            _comment = comment;
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

        public async Task<IActionResult> Single(int id)
        {
            var webApp = await _webApp.GetSingle(id);
            webApp.Comment = new CreateCommentDto
            {
                WebApplicationId = webApp.Id
            };
            return View(webApp);
        }

        [HttpPost]
        public async Task<IActionResult> Single(CreateCommentDto comment, int id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _comment.Add(comment, cancellationToken);
                if (result.Success)
                    return RedirectToAction("Single", new { Id = id });
            }
            return View(comment);
        }
    }
}
