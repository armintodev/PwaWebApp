using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Address
{
    public record AddressSearchDto : IDto
    {
        public string City { get; init; }
        public string Province { get; init; }
        public string Country { get; init; }
    }
}
