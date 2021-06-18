using Microsoft.AspNetCore.Mvc;
using Pwa.Application.Contracts.Account.User;
using System.Threading.Tasks;

namespace Pwa.Web.Areas.Admin.ViewComponents
{
    public class AdminInfoViewComponent : ViewComponent
    {
        private readonly IUserApplication _user;
        public AdminInfoViewComponent(IUserApplication user)
        {
            _user = user;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var admin = await _user.GetAdmin();
            return View(admin);
        }
    }
}
