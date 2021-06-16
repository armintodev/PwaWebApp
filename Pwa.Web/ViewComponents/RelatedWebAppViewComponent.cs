using Microsoft.AspNetCore.Mvc;
using Pwa.Query.Contracts.WebApp;
using System.Threading.Tasks;

namespace Pwa.Web.ViewComponents
{
    public class RelatedWebAppViewComponent : ViewComponent
    {
        private readonly IWebAppQuery _webApp;
        public RelatedWebAppViewComponent(IWebAppQuery webApp)
        {
            _webApp = webApp;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var webApps = await _webApp.RelatedApps(id);
            return View(webApps);
        }
    }
}
