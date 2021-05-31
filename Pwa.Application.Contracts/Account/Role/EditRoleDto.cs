using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Role
{
    public record EditRoleDto : CreateRoleDto, IDto
    {
        public int Id { get; init; }
    }
}
