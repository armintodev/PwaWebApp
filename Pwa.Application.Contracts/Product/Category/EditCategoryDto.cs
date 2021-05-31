using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.Category
{
    public record EditCategoryDto : CreateCategoryDto, IDto
    {
        public int Id { get; init; }
    }
}
