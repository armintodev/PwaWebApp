using Pwa.Domain.Product;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pwa.Infrastructure.EfCore.SeedData
{
    public class CategoryInitializer : IDataInitializer
    {
        private readonly ICategoryRepository _category;
        public CategoryInitializer(ICategoryRepository category)
        {
            _category = category;
        }

        public async Task Initialize()
        {
            if (_category.TableNoTracking.Any() is false)
            {
                List<Category> categories = new();
                categories.Add(new("کاربردی"));
                categories.Add(new("ابزار"));
                categories.Add(new("فروشگاهی"));
                categories.Add(new("پزشکی"));
                categories.Add(new("ورزشی"));
                categories.Add(new("سرگرمی"));
                categories.Add(new("کتاب"));
                categories.Add(new("تناسب اندام"));
                categories.Add(new("موسیقی"));
                categories.Add(new("فیلم و سریال"));
                categories.Add(new("برنامه نویسی"));

                await _category.AddRangeAsync(categories, CancellationToken.None);
            }
        }
    }
}
