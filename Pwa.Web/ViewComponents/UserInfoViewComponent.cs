using Microsoft.AspNetCore.Mvc;
using Pwa.Query.Contracts.User;
using System.Threading.Tasks;

namespace Pwa.Web.ViewComponents
{
    public class UserInfoViewComponent : ViewComponent
    {
        public readonly IUserQuery _user;
        public UserInfoViewComponent(IUserQuery user)
        {
            _user = user;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _user.Info();
            return View(user);
        }
    }
}
