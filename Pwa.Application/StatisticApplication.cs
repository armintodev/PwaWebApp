using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pwa.Application.Contracts.Account.Statistic;
using Pwa.Domain.Account;
using WebFramework.Utilities;

namespace Pwa.Application
{
    public class StatisticApplication : IStatisticApplication
    {
        private readonly IStatisticRepository _statistic;
        private readonly IHttpContextAccessor _accessor;
        public StatisticApplication(IStatisticRepository statistic, IHttpContextAccessor accessor)
        {
            _statistic = statistic;
            _accessor = accessor;
        }

        public async Task<OperationResult> Add(CreateStatisticDto createStatistic)
        {
            if (createStatistic is null) return new OperationResult(false, "اطلاعات نمی تواند خالی باشد");

            // I use this when authentication is right
            var userId = _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            Statistic statistic =
                new(createStatistic.IpAddress, createStatistic.Path, createStatistic.Browser, createStatistic.Device,
                    createStatistic.Os, createStatistic.Version, Convert.ToInt32(userId));

            await _statistic.AddAsync(statistic, CancellationToken.None);
            await _statistic.SaveChangesAsync();

            return new OperationResult(true, "اطلاعات با موفقیت اضافه شد.");
        }
    }
}
