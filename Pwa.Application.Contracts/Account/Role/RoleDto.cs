using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Role
{
    public record RoleDto : IDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}
