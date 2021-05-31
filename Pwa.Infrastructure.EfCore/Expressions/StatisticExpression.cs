using Pwa.Application.Contracts.Account.Statistic;
using Pwa.Domain.Account;
using System;
using System.Linq.Expressions;

namespace Pwa.Infrastructure.EfCore.Expressions
{
    public static class StatisticExpression
    {
        public static Expression<Func<Statistic, StatisticDto>> ToDto => _ => new StatisticDto
        {
            Id = _.Id,
            IpAddress = _.IpAddress,
            Browser = _.Browser,
            Device = _.Device,
            Os = _.Os,
            Version = _.Version,
            CreationDate = _.CreationDate.ToString()
        };
    }
}
