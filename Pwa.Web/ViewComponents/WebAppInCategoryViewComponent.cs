using Microsoft.AspNetCore.Mvc;
using Pwa.Query.Contracts.Category;
using System.Threading.Tasks;

namespace Pwa.Web.ViewComponents
{
    public class WebAppInCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryQuery _category;
        public WebAppInCategoryViewComponent(ICategoryQuery category)
        {
            _category = category;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _category.GetProductInCategory();
            return View(categories);
        }
    }
}
