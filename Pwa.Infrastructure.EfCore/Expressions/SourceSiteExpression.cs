using Pwa.Application.Contracts.Product.SourceSite;
using Pwa.Domain.Product;
using System;
using System.Linq.Expressions;

namespace Pwa.Infrastructure.EfCore.Expressions
{
    public static class SourceSiteExpression
    {
        public static Expression<Func<SourceSite, SourceSiteDto>> ToDto => _ => new SourceSiteDto
        {
            Id = _.Id,
            Name = _.Name,
            Address = _.Address,
            IsPwa = _.IsPwa,
            UserId = _.UserId,
            UserFullName = _.User.FullName,
            UserPhoneNumber = _.User.PhoneNumber
        };

        //to create source site , maybe i use to CreateSourceSiteDto rather than SourceSiteDto
        public static Expression<Func<SourceSiteDto, SourceSite>> FromDto => _ => new SourceSite(_.Name, _.Description, _.Address, null, _.IsPwa, _.UserId)
        {
            Id = _.Id
        };
    }
}
