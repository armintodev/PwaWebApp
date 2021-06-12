using Microsoft.EntityFrameworkCore;
using Pwa.Domain.Account;
using System.Threading.Tasks;
using WebFramework.Infrastructure;

namespace Pwa.Infrastructure.EfCore.Repositories
{
    public class DeveloperRepository : BaseRepository<Developer>, IDeveloperRepository
    {
        private readonly ApplicationDbContext _context;
        public DeveloperRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Developer> GetByEmail(string email)
        {
            return await _context.Developers.FirstOrDefaultAsync(_ => _.User.Email == email);
        }
    }
}
