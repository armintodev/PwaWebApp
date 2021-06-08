using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.Category
{
    public record CategoryDto : IDto
    {
        [Display(Name = "آی دی")]
        public int Id { get; init; }

        [Display(Name = "عنوان")]
        public string Title { get; init; }

        [Display(Name = "تاریخ ایجاد")]
        public string CreationDate { get; init; }

        [Display(Name = "تاریخ ویرایش")]
        public string LastEditDate { get; init; }
    }
}
