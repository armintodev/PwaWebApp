using Pwa.Application.Contracts.Account.User;
using Pwa.Domain.Account;

namespace Pwa.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _user;
        public UserApplication(IUserRepository user)
        {
            _user = user;
        }
    }
}
