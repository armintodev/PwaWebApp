
using Microsoft.AspNetCore.Mvc;
using Pwa.Application.Contracts.Product.Comment;
using System.Threading;
using System.Threading.Tasks;

namespace Pwa.Web.Areas.Admin.Controllers
{
    public class CommentController : AdminBaseController
    {
        private readonly ICommentApplication _comment;
        public CommentController(ICommentApplication comment)
        {
            _comment = comment;
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _comment.Delete(id, cancellationToken);
            if (result.Success is false)
                return NotFound();
            return RedirectToAction("Index", "WebApp");
        }

        public async Task<IActionResult> Detail(int id, CancellationToken cancellationToken)
        {
            var comment = await _comment.Detail(id, cancellationToken);
            if (comment is null)
                return NotFound();
            return View(comment.Data);
        }

        public async Task<IActionResult> Accept(int id, CancellationToken cancellationToken)
        {
            var comment = await _comment.Get(id, cancellationToken);
            if (comment.Success is false)
                return NotFound();

            await _comment.Accepted(id, cancellationToken);
            return RedirectToAction("Index", "WebApp");
        }

        public async Task<IActionResult> Reject(int id, CancellationToken cancellationToken)
        {
            var comment = await _comment.Get(id, cancellationToken);
            if (comment.Success is false)
                return NotFound();

            await _comment.Rejected(id, cancellationToken);
            return RedirectToAction("Index", "WebApp");
        }
    }
}
