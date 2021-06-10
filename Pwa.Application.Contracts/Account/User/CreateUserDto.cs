using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.User
{
    public record CreateUserDto : IDto
    {
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        // [RegularExpression("", ErrorMessage = ValidationMessages.WrongPhoneNumber)]
        public string PhoneNumber { get; init; }

        [Display(Name = "نام کامل")]
        public string FullName { get; init; }

        public string Code { get; init; }

        public string Role { get; set; }
    }
}
