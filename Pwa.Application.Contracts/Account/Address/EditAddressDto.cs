using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Address
{
    public record EditAddressDto : CreateAddressDto, IDto
    {
        public int Id { get; init; }
    }
}
