using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Statistic
{
    public record StatisticSearchDto : IDto
    {
        public string Browser { get; init; }
        public string Os { get; init; }
        public string Device { get; init; }
    }
}
