using System.Threading.Tasks;
using WebFramework.Domain;

namespace Pwa.Domain.Account
{
    public interface IDeveloperRepository : IBaseRepository<Developer>
    {
        Task<Developer> GetByEmail(string email);
    }
}
