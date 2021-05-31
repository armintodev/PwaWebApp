using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.Ticket
{
    public record CreateTicketDto : IDto
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MaxLength(500, ErrorMessage = ValidationMessages.WrongMaxLength)]
        public string Title { get; init; }

        [Display(Name = "توضیح")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Description { get; init; }

        public int DeveloperId { get; init; }
    }
}
