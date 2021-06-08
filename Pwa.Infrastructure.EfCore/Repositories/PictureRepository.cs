using Pwa.Domain.Product;
using WebFramework.Infrastructure;

namespace Pwa.Infrastructure.EfCore.Repositories
{
    public class PictureRepository : BaseRepository<Picture>, IPictureRepository
    {
        private readonly ApplicationDbContext _context;
        public PictureRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
