using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pwa.Application.Contracts.Product.Category;
using Pwa.Application.Contracts.Product.Comment;
using Pwa.Application.Contracts.Product.WebApplication;
using System.Threading;
using System.Threading.Tasks;

namespace Pwa.Web.Areas.Admin.Controllers
{
    public class WebAppController : AdminBaseController
    {
        private readonly IWebApplicationApplication _webApplication;
        private readonly ICategoryApplication _categoryApplication;
        private readonly ICommentApplication _commentApplication;
        public WebAppController(IWebApplicationApplication webApplication, ICategoryApplication categoryApplication, ICommentApplication commentApplication)
        {
            _webApplication = webApplication;
            _categoryApplication = categoryApplication;
            _commentApplication = commentApplication;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _webApplication.List();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryApplication.List();

            CreateWebApplicationDto model = new()
            {
                Categories = new SelectList(categories, "Id", "Title")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWebApplicationDto dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _webApplication.Create(dto, cancellationToken);
                if (result.Success)
                    return RedirectToAction("Index");

                ModelState.AddModelError("WebSiteAddress", result.Message);
            }
            CreateWebApplicationDto model = new()
            {
                Categories = new SelectList(await _categoryApplication.List(), "Id", "Title")
            };
            dto.Categories = model.Categories;
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var webApp = await _webApplication.Get(id);
            if (webApp.Success is false)
                return NotFound();
            return View(webApp.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditWebApplicationDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _webApplication.Edit(dto);
                if (result.Success)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var webApp = await _webApplication.Detail(id);
            if (webApp.Success is false)
                return NotFound();

            return View(webApp.Data);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var webApp = await _webApplication.Get(id);
            if (webApp.Success is false)
                return NotFound();

            var result = await _webApplication.Delete(id);
            if (result.Success)
                return RedirectToAction("Index");

            return BadRequest(result.Message);
        }

        public async Task<IActionResult> Activate(int id, CancellationToken cancellationToken)
        {
            var webApp = await _webApplication.Get(id);
            if (webApp.Success is false)
                return NotFound();

            await _webApplication.Activate(id, cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeActivate(int id, CancellationToken cancellationToken)
        {
            var webApp = await _webApplication.Get(id);
            if (webApp.Success is false)
                return NotFound();

            await _webApplication.DeActivate(id, cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CommentDetail(int id, CancellationToken cancellationToken)
        {
            var comments = await _commentApplication.List(id, cancellationToken);
            return View(comments);
        }
    }
}
