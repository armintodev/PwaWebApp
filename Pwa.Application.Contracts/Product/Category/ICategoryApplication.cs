using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.Category
{
    public interface ICategoryApplication
    {
        Task<List<CategoryDto>> List();
        Task<OperationResult> Create(CreateCategoryDto dto);
        Task<OperationResult<EditCategoryDto>> Get(int id);
        Task<OperationResult<CategoryDto>> Detail(int id);
        Task<OperationResult> Delete(int id);
        Task<OperationResult> Edit(EditCategoryDto dto);
    }
}
