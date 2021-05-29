using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Developer
{
    public record CreateDeveloperDto : IDto
    {
        public string FullName { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public string NationalCode { get; init; }
        public int AddressId { get; init; }
        public int StatisticId { get; init; }
    }
}
