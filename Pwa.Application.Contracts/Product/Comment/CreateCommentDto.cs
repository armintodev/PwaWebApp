using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.Comment
{
    public record CreateCommentDto : IDto
    {
        [Display(Name = "توضیح")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Description { get; init; }
        public int UserId { get; init; }
        public int WebApplicationId { get; init; }
    }
}
