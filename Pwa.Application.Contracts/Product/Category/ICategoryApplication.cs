using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pwa.Application.Contracts.Product.Category
{
    public interface ICategoryApplication
    {
        Task<List<CategoryDto>> List();
    }
}
