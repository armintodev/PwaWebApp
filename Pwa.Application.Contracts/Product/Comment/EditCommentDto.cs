using WebFramework.Enums;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.Comment
{
    public record EditCommentDto : CreateCommentDto, IDto
    {
        public int Id { get; init; }
        public StatusDto Status { get; init; }
    }
}
