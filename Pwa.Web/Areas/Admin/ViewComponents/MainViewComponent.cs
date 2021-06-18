using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pwa.Application.Contracts;
using Pwa.Infrastructure.EfCore;
using System.Threading.Tasks;

namespace Pwa.Web.Areas.Admin.ViewComponents
{
    public class MainViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public MainViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var counts = new MainDto
            {
                UserCount = await _context.Users.AsNoTracking().CountAsync(),
                WebAppCount = await _context.WebApplications.AsNoTracking().CountAsync(),
                CategoryCount = await _context.Categories.AsNoTracking().CountAsync()
            };

            return View(counts);
        }
    }
}
