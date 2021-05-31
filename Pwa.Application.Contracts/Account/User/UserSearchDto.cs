using WebFramework.Enums;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.User
{
    public record UserSearchDto : IDto
    {
        public string PhoneNumber { get; init; }
        public string Email { get; set; }
        public string FullName { get; init; }
        public StatusDto Status { get; init; }
    }
}
