using Microsoft.AspNetCore.Mvc;
using Pwa.Query.Contracts.WebApp;
using System.Threading.Tasks;

namespace Pwa.Web.ViewComponents
{
    public class ProductInCategoryViewComponent : ViewComponent
    {
        private readonly IWebAppQuery _webApp;
        public ProductInCategoryViewComponent(IWebAppQuery webApp)
        {
            _webApp = webApp;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
