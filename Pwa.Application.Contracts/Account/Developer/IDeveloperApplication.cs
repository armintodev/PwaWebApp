using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.Developer
{
    public interface IDeveloperApplication
    {
        Task<List<DeveloperDto>> ListAsync();
        Task<OperationResult<EditDeveloperDto>> Get(int id);
        Task<OperationResult> Register(CreateDeveloperDto register, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditDeveloperDto edit);
        Task<OperationResult> Delete(int id);
        Task Activate(int id);
        Task DeActivate(int id);
        Task<OperationResult> VerifyBySms(string code);
        Task<OperationResult<DeveloperDto>> Detail(int id);
    }
}
