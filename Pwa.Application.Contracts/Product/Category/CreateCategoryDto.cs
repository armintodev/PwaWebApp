using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.Category
{
    public record CreateCategoryDto : IDto
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Title { get; init; }
    }
}
