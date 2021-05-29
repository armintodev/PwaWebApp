using Pwa.Application.Contracts.Account.Developer;
using Pwa.Domain.Account;

namespace Pwa.Application
{
    public class DeveloperApplication : IDeveloperApplication<DeveloperDto>
    {
        private readonly IDeveloperRepository _developer;
        public DeveloperApplication(IDeveloperRepository developer)
        {
            _developer = developer;
        }
    }
}
