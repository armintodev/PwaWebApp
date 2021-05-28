using Pwa.Domain.Account;
using WebFramework.Infrastructure;

namespace Pwa.Infrastructure.EfCore.Repositories
{
    public class StatisticRepository : BaseRepository<Statistic>, IStatisticRepository
    {
        private readonly ApplicationDbContext _context;

        public StatisticRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
