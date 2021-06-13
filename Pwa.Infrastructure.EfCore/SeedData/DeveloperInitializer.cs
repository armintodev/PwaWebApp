using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pwa.Domain.Account;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Enums;

namespace Pwa.Infrastructure.EfCore.SeedData
{
    public class DeveloperInitializer : IDataInitializer
    {
        private readonly IUserRepository _user;
        private readonly IDeveloperRepository _developer;
        private readonly UserManager<User> _manager;
        public DeveloperInitializer(IUserRepository user, IDeveloperRepository developer, UserManager<User> manager)
        {
            _user = user;
            _developer = developer;
            _manager = manager;
        }
        public async Task Initialize()
        {
            if (await _developer.TableNoTracking.AnyAsync() is false)
            {
                User user1 = new("arminprgrmcsfamily@gmail.com", "Armin_Habibi", "09046642320", "آرمین حبیبی");
                await _manager.CreateAsync(user1);
                await _manager.AddToRoleAsync(user1, RoleStatus.Developer.ToString());
                Developer developer1 = new(user1.Id, "2130862101", "ایران", "مازندران", "ایران", "Developer/img_applications1.png");
                await _developer.AddAsync(developer1, CancellationToken.None);

                User user2 = new("iliaFara@gmail.com", "IliaFara", "09118613955", "ایلیا فرامرزپور");
                await _manager.CreateAsync(user2);
                await _manager.AddToRoleAsync(user2, RoleStatus.Developer.ToString());
                Developer developer2 = new(user2.Id, "2130862101", "ایران", "مازندران", "ایران", "Developer/img_applications2");
                await _developer.AddAsync(developer2, CancellationToken.None);

                User user3 = new("moshamekh@gmail.com", "MoShamekhi", "09113458382", "محمد شامخی");
                await _manager.CreateAsync(user3);
                await _manager.AddToRoleAsync(user3, RoleStatus.Developer.ToString());
                Developer developer3 = new(user3.Id, "2130862101", "ایران", "مازندران", "ایران", "Developer/img_applications3");
                await _developer.AddAsync(developer3, CancellationToken.None);

                User user4 = new("maf8032@gmail.com", "Maf8032", "09303495823", "محمدرضا افرازیده");
                await _manager.CreateAsync(user4);
                await _manager.AddToRoleAsync(user4, RoleStatus.Developer.ToString());
                Developer developer4 = new(user4.Id, "2130862101", "ایران", "مازندران", "ایران", "Developer/img_applications4");
                await _developer.AddAsync(developer4, CancellationToken.None);
            }
        }
    }
}
