using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.Ticket
{
    public record TicketDto : IDto
    {
        [Display(Name = "آی دی")]
        public int Id { get; init; }

        [Display(Name = "عنوان")]
        public string Title { get; init; }

        [Display(Name = "توضیحات")]
        public string Description { get; init; }

        [Display(Name = "")]
        public int DeveloperId { get; init; }

        [Display(Name = "نام توسعه دهنده")]
        public string DeveloperFullName { get; init; }

        [Display(Name = "ایمیل توسعه دهنده")]
        public string DeveloperEmail { get; init; }

        [Display(Name = "تاریخ ایجاد")]
        public string CreationDate { get; init; }

        [Display(Name = "تاریخ آخرین ویرایش")]
        public string LastEditDate { get; init; }
    }
}
