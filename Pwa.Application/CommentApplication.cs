using Microsoft.AspNetCore.Http;
using Pwa.Application.Contracts.Product.Comment;
using Pwa.Domain.Product;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Utilities;

namespace Pwa.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _comment;
        private readonly IHttpContextAccessor _accessor;
        public CommentApplication(ICommentRepository comment, IHttpContextAccessor accessor)
        {
            _comment = comment;
            _accessor = accessor;
        }

        public async Task<OperationResult> Add(CreateCommentDto dto, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(_accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            Comment comment = new(dto.Description, userId, dto.WebApplicationId);
            await _comment.AddAsync(comment, cancellationToken);
            return new OperationResult();
        }
    }
}
