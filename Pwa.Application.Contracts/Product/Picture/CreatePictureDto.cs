using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.Picture
{
    public class CreatePictureDto
    {
        [Display(Name = "تصویر")]
        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public IFormFile File { get; set; }
    }
}
