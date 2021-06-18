using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts
{
    public class MainDto : IDto
    {
        public int UserCount { get; init; }
        public int WebAppCount { get; init; }
        public int CategoryCount { get; init; }

    }
}
