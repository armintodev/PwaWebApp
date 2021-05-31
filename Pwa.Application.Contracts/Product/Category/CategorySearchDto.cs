using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.Category
{
    public record CategorySearchDto : IDto
    {
        public string Title { get; init; }
    }
}
