using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.User
{
    public record CreateUserDto : IDto
    {
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [RegularExpression("", ErrorMessage = ValidationMessages.WrongPhoneNumber)]
        public string PhoneNumber { get; init; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Password { get; init; }

        [Display(Name = "تایید کلمه عبور")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [Compare(nameof(Password), ErrorMessage = ValidationMessages.CheckPassword)]
        public string RePassword { get; init; }
        public string Code { get; init; }

        public string Role { get; set; }
    }
}
