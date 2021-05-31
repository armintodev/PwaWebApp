using Pwa.Domain.Product;
using WebFramework.Infrastructure;

namespace Pwa.Infrastructure.EfCore.Repositories
{
    public class SourceSiteRepository : BaseRepository<SourceSite>, ISourceSiteRepository
    {
        private readonly ApplicationDbContext _context;

        public SourceSiteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
