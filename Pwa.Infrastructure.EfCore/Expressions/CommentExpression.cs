using Pwa.Application.Contracts.Product.Comment;
using Pwa.Domain.Product;
using System;
using System.Linq.Expressions;
using WebFramework.Enums;

namespace Pwa.Infrastructure.EfCore.Expressions
{
    public static class CommentExpression
    {
        public static Expression<Func<Comment, CommentDto>> ToDto => _ => new CommentDto
        {
            Id = _.Id,
            Description = _.Description,
            IsDeveloper = _.IsDeveloper,
            Status = (StatusDto)_.Status,
            UserId = _.UserId,
            WebApplicationId = _.WebApplicationId,
            UserFullName = _.User.FullName,
            UserPhoneNumber = _.User.PhoneNumber,
            WebAppName = _.WebApplication.Name,
            WebAppAddress = _.WebApplication.WebSiteAddress
        };
    }
}
