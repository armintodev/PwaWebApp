using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.SourceSite
{
    public record EditSourceSiteDto : IDto
    {
        public int Id { get; init; }
    }
}
