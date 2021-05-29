using WebFramework.Enums;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Developer
{
    public record DeveloperDto : IDto
    {
        public int Id { get; init; }
        public string FullName { get; init; }
        public string NationalCode { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public StatusDto Status { get; init; }
        public string CreationDate { get; init; }
        public int AddressId { get; init; }
        public int StatisticId { get; init; }
    }
}
