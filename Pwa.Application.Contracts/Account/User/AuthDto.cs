using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.User
{
    public record AuthDto : IDto
    {
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string PhoneNumber { get; init; }

        [Display(Name = "نام کامل")]
        public string FullName { get; init; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; init; }

    }
}
