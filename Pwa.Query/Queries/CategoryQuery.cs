using Microsoft.EntityFrameworkCore;
using Pwa.Domain.Product;
using Pwa.Infrastructure.EfCore;
using Pwa.Query.Contracts.Category;
using Pwa.Query.Contracts.WebApp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Enums;

namespace Pwa.Query.Queries
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly ApplicationDbContext _context;
        public CategoryQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryQueryModel>> GetProductInCategory()
        {
            var categories = _context.Categories.Include(_ => _.WebApplications)
                .ThenInclude(_ => _.Category)
                .Include(_ => _.WebApplications)
                .ThenInclude(_ => _.Pictures)
                .Select(_ => new CategoryQueryModel
                {
                    Id = _.Id,
                    Title = _.Title,
                    WebApps = MapWebApps(_.WebApplications)
                }).AsNoTracking();

            return await categories.ToListAsync();
        }

        public async Task<List<CategoryQueryModel>> List()
        {
            var categories = _context.Categories.Select(_ => new CategoryQueryModel
            {
                Id = _.Id,
                Title = _.Title
            }).AsNoTracking();
            return await categories.ToListAsync();
        }

        private static List<WebAppQueryModel> MapWebApps(List<WebApplication> webApplications)
        {
            return webApplications.Where(_ => _.Status == Status.Active).Select(_ => new WebAppQueryModel
            {
                Id = _.Id,
                Name = _.Name,
                Category = _.Category.Title,
                Icon = _.Icon,
                Pictures = MapPictures(_.Pictures)
            }).ToList();
        }

        private static List<PictureQueryModel> MapPictures(List<Picture> pictures)
        {
            return pictures.Select(_ => new PictureQueryModel
            {
                Id = _.Id,
                Picture = _.FileName,
            }).ToList();
        }
    }
}
