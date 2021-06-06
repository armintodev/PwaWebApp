using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebFramework.Enums;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Developer
{
    public record DeveloperDto : IDto
    {
        public int Id { get; init; }

        [Display(Name = "نام کامل")]
        public string FullName { get; init; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; init; }

        [Display(Name = "کدملی")]
        public string NationalCode { get; init; }

        [Display(Name = "ایمیل")]
        public string Email { get; init; }

        [Display(Name = "شماره همراه")]
        public string PhoneNumber { get; init; }

        [Display(Name = "شهر")]
        public string City { get; init; }

        [Display(Name = "استان")]
        public string Province { get; init; }

        [Display(Name = "کشور")]
        public string Country { get; init; }

        [Display(Name = "تصویر پروفایل")]
        public string ProfileUrl { get; init; }

        [Display(Name = "کد فعال سازی")]
        public string Code { get; init; }

        [Display(Name = "وضعیت")]
        public StatusDto Status { get; init; }

        [Display(Name = "تاریخ ثبت نام")]
        public string CreationDate { get; init; }

        [Display(Name = "تاریخ آخرین ویرایش")]
        public string LastEditDate { get; init; }

        public List<int>? StatisticId { get; init; }
    }
}
