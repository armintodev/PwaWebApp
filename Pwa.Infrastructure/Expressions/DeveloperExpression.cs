using Pwa.Application.Contracts.Account.Developer;
using Pwa.Domain.Account;
using System;
using System.Linq.Expressions;
using WebFramework.Enums;

namespace Pwa.Infrastructure.EfCore.Expressions
{
    public static class DeveloperExpression
    {
        public static Expression<Func<Developer, DeveloperDto>> ToDto => developer => new DeveloperDto
        {
            Id = developer.Id,
            FullName = developer.FullName,
            Email = developer.Email,
            PhoneNumber = developer.PhoneNumber,
            NationalCode = developer.NationalCode,
            Status = (StatusDto)developer.Status,
            CreationDate = developer.CreationDate.ToString(),
            AddressId = developer.AddressId,
            StatisticId = developer.StatisticId
        };
    }
}
