using Microsoft.AspNetCore.Mvc;
using Pwa.Query.Contracts.WebApp;
using System.Threading.Tasks;

namespace Pwa.Web.ViewComponents
{
    public class MostVisitViewComponent : ViewComponent
    {
        private readonly IWebAppQuery _webApp;
        public MostVisitViewComponent(IWebAppQuery webApp)
        {
            _webApp = webApp;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var games = await _webApp.GetMostVisit();
            return View(games);
        }
    }
}
