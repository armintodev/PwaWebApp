using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.SourceSite
{
    public record CreateSourceSiteDto : IDto
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MaxLength(500,ErrorMessage =ValidationMessages.WrongMaxLength)]
        public string Name { get; init; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Address { get; init; }

        [Display(Name = "توشیح")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Description { get; init; }

        [Display(Name = "آیکون")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public byte[] Icons { get; init; }

        [Display(Name = "تایید کردن سایت")]
        public bool IsPwa { get; init; }
        public int UserId { get; init; }
    }
}
