using Pwa.Application.Contracts.Account.Developer;
using Pwa.Domain.Account;
using System;
using System.Linq.Expressions;
using WebFramework.Enums;

namespace Pwa.Infrastructure.EfCore.Expressions
{
    public static class DeveloperExpression
    {
        public static Expression<Func<Developer, DeveloperDto>> ToDto => _ => new DeveloperDto
        {
            Id = _.Id,
            FullName = _.FullName,
            Email = _.Email,
            PhoneNumber = _.PhoneNumber,
            NationalCode = _.NationalCode,
            Code = _.Code,
            Status = (StatusDto)_.Status,
            CreationDate = _.CreationDate.ToString(),
            AddressId = _.AddressId,
            StatisticId = _.StatisticId
        };
    }
}
