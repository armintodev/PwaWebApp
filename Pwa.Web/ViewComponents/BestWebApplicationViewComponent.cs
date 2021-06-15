using Microsoft.AspNetCore.Mvc;
using Pwa.Query.Contracts.WebApp;
using System.Threading.Tasks;

namespace Pwa.Web.ViewComponents
{
    public class BestWebApplicationViewComponent : ViewComponent
    {
        private readonly IWebAppQuery _webApp;
        public BestWebApplicationViewComponent(IWebAppQuery webApp)
        {
            _webApp = webApp;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var webApps = await _webApp.GetBests();
            return View(webApps);
        }
    }
}
