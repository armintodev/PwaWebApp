using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Developer
{
    public record EditDeveloperDto : CreateDeveloperDto, IDto
    {
        public int Id { get; init; }
    }
}
