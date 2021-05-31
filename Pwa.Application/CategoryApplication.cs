using Pwa.Application.Contracts.Product.Category;
using Pwa.Domain.Product;

namespace Pwa.Application
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _category;
        public CategoryApplication(ICategoryRepository category)
        {
            _category = category;
        }
    }
}
