using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Role
{
    public record RoleSearchDto : IDto
    {
        public string Name { get; init; }
    }
}
