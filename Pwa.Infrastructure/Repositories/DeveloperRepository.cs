using Pwa.Domain.Account;
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
    }
}
