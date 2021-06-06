using System.Collections.Generic;
using System.Threading.Tasks;
using Pwa.Application.Contracts.Account.User;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.Developer
{
    public interface IDeveloperApplication
    {
        Task<List<DeveloperDto>> ListAsync();
        Task<OperationResult<EditDeveloperDto>> Get(int id);
        Task<OperationResult> Login(LoginDto login);
        Task<OperationResult> Register(CreateDeveloperDto register);
        Task<OperationResult> Edit(EditDeveloperDto edit);
        Task<OperationResult> Delete(int id);
        Task Activate(int id);
        Task DeActivate(int id);
        Task<OperationResult<DeveloperDto>> Detail(int id);
    }
}
