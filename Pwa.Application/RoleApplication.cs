using Pwa.Application.Contracts.Account.Role;
using Pwa.Domain.Account;

namespace Pwa.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _role;
        public RoleApplication(IRoleRepository role)
        {
            _role = role;
        }
    }
}
