using WebFramework.Enums;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Developer
{
    public record DeveloperSearchDto : IDto
    {
        public string NationalCode { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public StatusDto Status { get; init; }
    }
}
