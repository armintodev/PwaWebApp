using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pwa.Domain.Account;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Enums;

namespace Pwa.Infrastructure.EfCore.SeedData
{
    public class UserInitializer : IDataInitializer
    {
        private readonly IUserRepository _user;
        private readonly UserManager<User> _manager;
        public UserInitializer(IUserRepository user, UserManager<User> manager)
        {
            _user = user;
            _manager = manager;
        }

        public async Task Initialize()
        {
            if (await _user.TableNoTracking.AnyAsync() is false)
            {
                List<User> users = new();
                users.Add(new("09106692003", profileUrl: "User/profile.png"));
                users.Add(new("09118613957", profileUrl: "User/profile.png"));
                users.Add(new("09111275582", profileUrl: "User/profile.png"));

                foreach (var user in users)
                {
                    await _manager.CreateAsync(user);
                    await _manager.AddToRoleAsync(user, RoleStatus.Basic.ToString());
                    await _manager.AddToRoleAsync(user, RoleStatus.Admin.ToString());
                }
            }
        }
    }
}
