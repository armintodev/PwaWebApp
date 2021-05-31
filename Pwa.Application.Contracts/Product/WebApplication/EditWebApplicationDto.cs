using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.WebApplication
{
    public record EditWebApplicationDto : IDto
    {
        public string Id { get; init; }
    }
}
