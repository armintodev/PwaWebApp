using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Statistic
{
    public record EditStatisticDto : IDto
    {
        public int Id { get; init; }
    }
}
