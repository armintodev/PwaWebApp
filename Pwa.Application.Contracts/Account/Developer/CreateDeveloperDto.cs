using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.Developer
{
    public record CreateDeveloperDto : IDto
    {
        [Display(Name = "نام کامل")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string FullName { get; init; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Email { get; init; }

        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string PhoneNumber { get; init; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Password { get; init; }

        [Display(Name = "تایید کلمه عبور")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [Compare(nameof(Password), ErrorMessage = ValidationMessages.CheckPassword)]
        public string RePassword { get; init; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string NationalCode { get; init; }
        public string Code { get; init; }

        public int AddressId { get; init; }
        public int StatisticId { get; init; }
    }
}
