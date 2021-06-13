using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pwa.Domain.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pwa.Infrastructure.EfCore.SeedData
{
    public class RoleInitializer : IDataInitializer
    {
        private readonly IRoleRepository _role;
        private readonly RoleManager<Role> _manager;
        public RoleInitializer(IRoleRepository role, RoleManager<Role> manager)
        {
            _role = role;
            _manager = manager;
        }

        public async Task Initialize()
        {
            if (await _role.TableNoTracking.AnyAsync() is false)
            {
                List<Role> roles = new();
                roles.Add(new("Basic", "کاربر عادی"));
                roles.Add(new("Admin", "مدیر"));
                roles.Add(new("Developer", "توسعه دهنده"));

                foreach (var role in roles)
                {
                    await _manager.CreateAsync(role);
                }
            }
        }
    }
}
