using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Statistic
{
    public record StatisticDto : IDto
    {
        public int Id { get; init; }
        public string Browser { get; init; }
        public string IpAddress { get; init; }
        public string Device { get; init; }
        public string Os { get; init; }
        public string Version { get; init; }
        public string CreationDate { get; init; }
    }
}
