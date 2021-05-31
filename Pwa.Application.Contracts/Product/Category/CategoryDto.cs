using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.Category
{
    public record CategoryDto : IDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
    }
}
