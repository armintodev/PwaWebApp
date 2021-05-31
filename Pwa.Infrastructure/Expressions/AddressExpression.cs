using Pwa.Application.Contracts.Account.Address;
using Pwa.Domain.Account;
using System;
using System.Linq.Expressions;

namespace Pwa.Infrastructure.EfCore.Expressions
{
    public static class AddressExpression
    {
        public static Expression<Func<Address, AddressDto>> ToDto => _ => new AddressDto
        {
            Id = _.Id,
            City = _.City,
            Province = _.Province,
            Country = _.Country,
            CreationDate = _.CreationDate.ToString(),
        };
    }
}
