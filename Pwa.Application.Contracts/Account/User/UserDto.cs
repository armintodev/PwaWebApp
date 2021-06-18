using System.ComponentModel.DataAnnotations;
using Pwa.Application.Contracts.Account.Developer;
using WebFramework.Enums;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.User
{
    public record UserDto : IDto
    {
        [Display(Name = "آی دی")]
        public int Id { get; init; }

        [Display(Name = "نام کامل")]
        public string FullName { get; init; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; init; }

        [Display(Name = "ایمیل")]
        public string Email { get; init; }

        [Display(Name = "شماره همراه")]
        public string PhoneNumber { get; init; }

        [Display(Name = "تصویر پروفایل")]
        public string ProfileUrl { get; init; }

        [Display(Name = "کد فعال سازی")]
        public string Code { get; init; }

        [Display(Name = "وضعیت")]
        public StatusDto Status { get; init; }

        [Display(Name = "نقش")]
        public RoleStatusDto Role { get; init; }

        [Display(Name = "تاریخ ایجاد")]
        public string CreationDate { get; init; }

        [Display(Name = "تاریخ آخرین ویرایش")]
        public string LastEditDate { get; init; }

        public DeveloperDto Developer { get; init; }
    }
}
