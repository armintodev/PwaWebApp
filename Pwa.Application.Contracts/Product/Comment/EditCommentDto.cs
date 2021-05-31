using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.Comment
{
    public record EditCommentDto : CreateCommentDto, IDto
    {
        public int Id { get; init; }
    }
}
