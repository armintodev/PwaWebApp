using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using WebFramework.Enums;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.WebApplication
{
    public record EditWebApplicationDto : IDto
    {
        public int Id { get; init; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MaxLength(500, ErrorMessage = ValidationMessages.WrongMaxLength)]
        public string Name { get; init; }

        [Display(Name = "توضیح")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Description { get; init; }

        [Display(Name = "آیکون")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public IFormFile Icon { get; init; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public StatusDto Status { get; init; }
        public IFormFileCollection Files { get; set; }
        public List<IFormFile> Files2 { get; set; }
    }
}
