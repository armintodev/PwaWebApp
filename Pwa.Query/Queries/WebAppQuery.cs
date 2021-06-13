using Pwa.Infrastructure.EfCore;
using Pwa.Query.Contracts.Category;
using Pwa.Query.Contracts.WebApp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pwa.Query.Queries
{
    public class WebAppQuery : IWebAppQuery
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryQuery _category;
        public WebAppQuery(ApplicationDbContext context, ICategoryQuery category)
        {
            _context = context;
            _category = category;
        }

        public async Task<List<WebAppQueryModel>> GetInCategory()
        {
            //var categories = await _category.List();
            throw new System.NotImplementedException();
        }

        public Task<List<WebAppQueryModel>> GetMostVisited()
        {
            throw new System.NotImplementedException();
        }
    }
}
