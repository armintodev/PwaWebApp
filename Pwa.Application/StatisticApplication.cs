using Pwa.Application.Contracts.Account.Statistic;
using Pwa.Domain.Account;

namespace Pwa.Application
{
    public class StatisticApplication : IStatisticApplication
    {
        private readonly IStatisticRepository _statistic;
        public StatisticApplication(IStatisticRepository statistic)
        {
            _statistic = statistic;
        }
    }
}
