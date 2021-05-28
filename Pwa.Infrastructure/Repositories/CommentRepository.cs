using Pwa.Domain.Product;
using WebFramework.Infrastructure;

namespace Pwa.Infrastructure.EfCore.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
