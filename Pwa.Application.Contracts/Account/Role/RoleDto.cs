using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Role
{
    public record RoleDto : IDto
    {
        [Display(Name = "آی دی")]
        public int Id { get; init; }

        [Display(Name = "نام")]
        public string Name { get; init; }

        [Display(Name = "نام نمایشی")]
        public string DisplayName { get; init; }

        [Display(Name = "تاریخ ایجاد")]
        public string CreationDate { get; init; }

        [Display(Name = "تاریخ آخرین ویرایش")]
        public string LastEditDate { get; init; }
    }
}
