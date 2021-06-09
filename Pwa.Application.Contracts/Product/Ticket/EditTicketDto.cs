using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.Ticket
{
    public record EditTicketDto : CreateTicketDto, IDto
    {
        public int Id { get; init; }

        [Display(Name = "نام توسعه دهنده")]
        public string DeveloperFullName { get; init; }

        [Display(Name = "ایمیل توسعه دهنده")]
        public string DeveloperEmail { get; init; }
    }
}
