using Pwa.Application.Contracts.Product.Ticket;
using Pwa.Domain.Product;
using System;
using System.Linq.Expressions;

namespace Pwa.Infrastructure.EfCore.Expressions
{
    public static class TicketExpression
    {
        public static Expression<Func<Ticket, TicketDto>> ToDto => _ => new TicketDto
        {
            Id = _.Id,
            Title = _.Title,
            Description = _.Description,
            DeveloperId = _.DeveloperId,
            DeveloperFullName = _.Developer.FullName,
            DeveloperEmail = _.Developer.Email
        };
    }
}
