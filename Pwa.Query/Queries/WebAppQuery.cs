using Microsoft.EntityFrameworkCore;
using Pwa.Infrastructure.EfCore;
using Pwa.Query.Contracts.WebApp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pwa.Query.Queries
{
    public class WebAppQuery : IWebAppQuery
    {
        private readonly ApplicationDbContext _context;
        public WebAppQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WebAppQueryModel>> GetBests()
        {
            var webApps = _context.WebApplications.Select(_ => new WebAppQueryModel
            {
                Id = _.Id,
                Name = _.Name,
                Address = _.WebSiteAddress,
                Category = _.Category.Title,
                Icon = _.Icon,
                Visit = _.Visit
            }).AsNoTracking();


            return await webApps.ToListAsync();
        }

        public async Task<List<WebAppQueryModel>> GetGames()
        {
            var games = _context.WebApplications.Include(_ => _.Pictures).Where(_ => _.IsGame).Select(_ => new WebAppQueryModel
            {
                Id = _.Id,
                Name = _.Name,
                Description = _.Description.Substring(0, 30),
                Address = _.WebSiteAddress,
                Picture = _.Pictures.Select(_ => _.FileName).First(),
                Visit = _.Visit
            }).AsNoTracking();

            return await games.ToListAsync();
        }

        public async Task<List<WebAppQueryModel>> GetMostVisit()
        {
            var webApps = _context.WebApplications.Include(_ => _.Pictures).Select(_ => new WebAppQueryModel
            {
                Id = _.Id,
                Name = _.Name,
                Address = _.WebSiteAddress,
                Picture = _.Pictures.Select(_ => _.FileName).First(),
                Visit = _.Visit
            }).AsNoTracking();

            return await webApps.Take(5).ToListAsync();
        }
    }
}
