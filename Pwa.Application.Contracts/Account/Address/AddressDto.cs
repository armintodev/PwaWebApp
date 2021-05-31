using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Address
{
    public record AddressDto : IDto
    {
        public int Id { get; init; }
        public string City { get; init; }
        public string Province { get; init; }
        public string Country { get; init; }
        public string CreationDate { get; init; }
    }
}
