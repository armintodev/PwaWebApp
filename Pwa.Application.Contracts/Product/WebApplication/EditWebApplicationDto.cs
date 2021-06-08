using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.WebApplication
{
    public record EditWebApplicationDto : CreateWebApplicationDto, IDto
    {
        public int Id { get; init; }
    }
}
