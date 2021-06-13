using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pwa.Query.Contracts.Category
{
    public interface ICategoryQuery
    {
        Task<List<CategoryQueryModel>> List();
        Task<List<CategoryQueryModel>> GetProductInCategory();
    }
}
