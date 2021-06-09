using Microsoft.AspNetCore.Mvc;
using Pwa.Application.Contracts.Product.Category;
using System.Threading.Tasks;

namespace Pwa.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryApplication _category;
        public CategoryController(ICategoryApplication category)
        {
            _category = category;
        }

        public async Task<IActionResult> Index()
        {
            var category = await _category.List();
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _category.Create(dto);
                if (result.Success)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _category.Get(id);
            if (category.Success is false)
                return NotFound();
            return View(category.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _category.Edit(dto);
                if (result.Success)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var category = await _category.Detail(id);
            if (category.Success is false)
                return NotFound();

            return View(category.Data);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _category.Get(id);
            if (category.Success is false)
                return NotFound();

            var result = await _category.Delete(id);
            if (result.Success)
                return RedirectToAction("Index");

            return BadRequest(result.Message);
        }
    }
}
