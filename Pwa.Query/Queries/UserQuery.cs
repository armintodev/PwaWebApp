using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Pwa.Domain.Account;
using Pwa.Query.Contracts.User;
using System.Threading.Tasks;

namespace Pwa.Query.Queries
{
    public class UserQuery : IUserQuery
    {
        private readonly UserManager<User> _user;
        private readonly IHttpContextAccessor _accessor;
        public UserQuery(UserManager<User> user, IHttpContextAccessor accessor)
        {
            _user = user;
            _accessor = accessor;
        }

        public async Task<UserQueryModel> Info()
        {
            var user = await _user.GetUserAsync(_accessor.HttpContext.User);
            if (user is null)
                return new UserQueryModel();
            return new UserQueryModel
            {
                Name = user.UserName,
                ProfileUrl = user.ProfileUrl,
                IsAdmin = await _user.IsInRoleAsync(user, "Admin")
            };
        }
    }
}
