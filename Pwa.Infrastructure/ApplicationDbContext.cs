using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pwa.Domain.Account;

namespace Pwa.Infrastructure.EfCore
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
