using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.Picture
{
    public class PictureDto : IDto
    {
        [Display(Name = "تصویر")]
        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public IFormFile File { get; init; }

        public string PictureName { get; set; }

        [Display(Name = "تاریخ ایجاد عکس")]
        public string CreationDate { get; init; }
    }
}
