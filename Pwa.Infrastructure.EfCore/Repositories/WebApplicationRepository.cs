using Pwa.Domain.Product;
using WebFramework.Infrastructure;

namespace Pwa.Infrastructure.EfCore.Repositories
{
    public class WebApplicationRepository : BaseRepository<WebApplication>, IWebApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public WebApplicationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
