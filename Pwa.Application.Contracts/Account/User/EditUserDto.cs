using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.User
{
    public record EditUserDto : CreateUserDto, IDto
    {
        public int Id { get; init; }
    }
}
