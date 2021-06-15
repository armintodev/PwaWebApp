using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.WebApplication
{
    public interface IWebApplicationApplication
    {
        Task<OperationResult> Create(CreateWebApplicationDto dto, CancellationToken cancellationToken);
        Task<List<WebApplicationDto>> List();
        Task<OperationResult<EditWebApplicationDto>> Get(int id);
        Task<OperationResult> Edit(EditWebApplicationDto dto);
        Task<OperationResult<WebApplicationDto>> Detail(int id);
        Task<OperationResult> Delete(int id);
    }
}
