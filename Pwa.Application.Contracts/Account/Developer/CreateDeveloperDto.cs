using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Pwa.Application.Contracts.Account.Statistic;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.Developer
{
    public record CreateDeveloperDto : IDto
    {
        [Display(Name = "نام کامل")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string FullName { get; init; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string UserName { get; init; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [EmailAddress(ErrorMessage = ValidationMessages.WrongEmail)]
        public string Email { get; init; }

        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string PhoneNumber { get; init; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [DataType(DataType.Password)]
        public string Password { get; init; }

        [Display(Name = "تایید کلمه عبور")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [Compare(nameof(Password), ErrorMessage = ValidationMessages.CheckPassword)]
        [DataType(DataType.Password)]
        public string RePassword { get; init; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string NationalCode { get; init; }
        public string Code { get; init; }

        [Display(Name = "شهرستان")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string City { get; init; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Province { get; init; }

        [Display(Name = "کشور")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Country { get; init; }

        [Display(Name = "تصویر پروفایل")]
        public IFormFile ProfileUrl { get; init; }

        public int StatisticId { get; init; }
        public CreateStatisticDto Statistic { get; init; }
    }
}
