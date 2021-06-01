using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pwa.Application.Contracts.Account.Developer
{
    public interface IDeveloperApplication
    {
        Task<List<DeveloperDto>> ListAsync();
        Task Login(CreateDeveloperDto login);
        Task Register(CreateDeveloperDto register);
        Task Edit(EditDeveloperDto edit);
        Task Delete(int id);
        Task Activate(int id);
        Task DeActivate(int id);
    }
}
