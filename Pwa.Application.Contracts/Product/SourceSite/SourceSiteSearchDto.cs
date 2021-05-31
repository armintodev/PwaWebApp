using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.SourceSite
{
    public record SourceSiteSearchDto : IDto
    {
        public string Name { get; init; }
        public string Address { get; init; }
        public string Description { get; init; }
    }
}
