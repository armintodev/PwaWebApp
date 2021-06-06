using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.Developer
{
    public record EditDeveloperDto : IDto
    {
        public int Id { get; init; }

        [Display(Name = "نام کامل")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string FullName { get; init; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string NationalCode { get; init; }

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
    }
}
