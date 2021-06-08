using Microsoft.EntityFrameworkCore;
using Pwa.Application.Contracts.Product.Category;
using Pwa.Domain.Product;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pwa.Application
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _category;
        public CategoryApplication(ICategoryRepository category)
        {
            _category = category;
        }

        public async Task<List<CategoryDto>> List()
        {
            var categories = _category.TableNoTracking.Select(_ => new CategoryDto
            {
                Id = _.Id,
                Title = _.Title
            });
            return await categories.ToListAsync();
        }
    }
}
