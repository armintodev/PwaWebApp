using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.Statistic
{
    public record CreateStatisticDto : IDto
    {
        [Display(Name = "آدرس آی پی")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string IpAddress { get; init; }

        [Display(Name = "مسیر درخواست")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Path { get; init; }

        [Display(Name = "مرورگر")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Browser { get; init; }

        [Display(Name = "دستگاه")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Device { get; init; }

        [Display(Name = "سیستم عامل")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Os { get; init; }

        [Display(Name = "نسخه")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Version { get; init; }
    }
}
