using Pwa.Application.Contracts.Product.WebApplication;
using Pwa.Domain.Product;
using System;
using System.Linq.Expressions;
using WebFramework.Enums;

namespace Pwa.Infrastructure.EfCore.Expressions
{
    public static class WebApplicationExpression
    {
        public static Expression<Func<WebApplication, WebApplicationDto>> ToDto => _ => new WebApplicationDto
        {
            Id = _.Id,
            Name = _.Name,
            Description = _.Description,
            WebSiteAddress = _.WebSiteAddress,
            Installed = _.Installed,
            Visit = _.Visit,
            Icons = _.Icons,
            Status = (StatusDto)_.Status,
            TypeAdd = (TypeAddDto)_.TypeAdd,
            CategoryId = _.CategoryId,
            DeveloperId = _.DeveloperId,
        };

        //to create web application , maybe i use to CreateWebApplicationDto rather than WebApplicationDto
        public static Expression<Func<WebApplicationDto, WebApplication>> FromDto => _ => new WebApplication(_.Name, _.Description, _.WebSiteAddress, _.Icons, (TypeAdd)_.TypeAdd, (Status)_.Status, _.CategoryId, _.DeveloperId)
        {
            Id = _.Id,
        };
    }
}
