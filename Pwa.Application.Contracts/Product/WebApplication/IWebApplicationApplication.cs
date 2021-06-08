using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.WebApplication
{
    public interface IWebApplicationApplication
    {
        Task<OperationResult> Create(CreateWebApplicationDto dto);
        Task<List<WebApplicationDto>> List();
    }
}
