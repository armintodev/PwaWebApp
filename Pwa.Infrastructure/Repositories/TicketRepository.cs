using Pwa.Domain.Product;
using WebFramework.Infrastructure;

namespace Pwa.Infrastructure.EfCore.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
