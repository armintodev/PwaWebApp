using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Pwa.Application.Contracts.Product.Comment;
using Pwa.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Enums;
using WebFramework.Infrastructure;
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

        public async Task Accepted(int id, CancellationToken cancellationToken)
        {
            var comment = await _comment.GetByIdAsync(cancellationToken, id);
            comment.Accept();
            await _comment.SaveChangesAsync();
        }

        public async Task Rejected(int id, CancellationToken cancellationToken)
        {
            var comment = await _comment.GetByIdAsync(cancellationToken, id);
            comment.Reject();
            await _comment.SaveChangesAsync();
        }

        public async Task<OperationResult> Add(CreateCommentDto dto, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(_accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            Comment comment = new(dto.Description, userId, dto.WebApplicationId);
            await _comment.AddAsync(comment, cancellationToken);
            return new OperationResult();
        }

        public async Task<OperationResult> Delete(int id, CancellationToken cancellationToken)
        {
            var comment = await _comment.GetByIdAsync(cancellationToken, id);
            if (comment is null)
                return new OperationResult(false, "کامنتی با این مشخصات پیدا نشد");
            await _comment.DeleteAsync(comment, cancellationToken);
            return new OperationResult();
        }

        public async Task<OperationResult<CommentDto>> Detail(int id, CancellationToken cancellationToken)
        {
            var comment = await _comment.TableNoTracking.Include(_ => _.User)
                .Include(_ => _.WebApplication)
                .FirstOrDefaultAsync(_ => _.Id == id);
            if (comment is null)
            {
                CommentDto nullCommentDto = new();
                return new OperationResult<CommentDto>(nullCommentDto, false, "کامنتی با این مشخصات پیدا نشد");
            }

            CommentDto data = new()
            {
                Id = comment.Id,
                Description = comment.Description,
                Status = (StatusDto)comment.Status,
                UserInfo = comment.User.FullName == null ? comment.User.UserName : comment.User.PhoneNumber,
                WebAppName = comment.WebApplication.Name,
                CreationDate = comment.CreationDate.ToFarsiFull()
            };

            return new OperationResult<CommentDto>(data);
        }

        public async Task<OperationResult<EditCommentDto>> Get(int id, CancellationToken cancellationToken)
        {
            var comment = await _comment.GetByIdAsync(cancellationToken, id);
            if (comment is null)
            {
                EditCommentDto nullEditCommentDto = new();
                return new OperationResult<EditCommentDto>(nullEditCommentDto, false, "کامنتی با این مشخصات وجود ندارد");
            }

            EditCommentDto data = new()
            {
                Id = comment.Id,
                Description = comment.Description,
                Status = (StatusDto)comment.Status
            };
            return new OperationResult<EditCommentDto>(data, true, "");
        }

        public async Task<List<CommentDto>> List(int id, CancellationToken cancellationToken)
        {
            return await _comment.TableNoTracking.Where(_ => _.WebApplicationId == id)
                .Include(_ => _.User)
                .Include(_ => _.WebApplication)
                .Select(_ => new CommentDto
                {
                    Id = _.Id,
                    Description = _.Description.Substring(0, 100),
                    UserInfo = _.User.FullName == null ? _.User.UserName : _.User.PhoneNumber,
                    WebAppName = _.WebApplication.Name,
                    Status = (StatusDto)_.Status
                }).AsNoTracking().ToListAsync();
        }
    }
}
