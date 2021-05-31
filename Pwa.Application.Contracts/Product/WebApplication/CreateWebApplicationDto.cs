﻿using System.ComponentModel.DataAnnotations;
using WebFramework.Enums;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Product.WebApplication
{
    public record CreateWebApplicationDto : IDto
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        [MaxLength(500, ErrorMessage = ValidationMessages.WrongMaxLength)]
        public string Name { get; init; }

        [Display(Name = "توضیح")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Description { get; init; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string WebSiteAddress { get; init; }

        [Display(Name = "آیکون")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public byte[] Icons { get; init; }

        [Display(Name = "نوع اضافه کردن")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public TypeAddDto TypeAdd { get; init; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public StatusDto Status { get; init; }

        [Display(Name = "تعداد بازدید")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public int Visit { get; init; }

        [Display(Name = "تعداد دریافت شده ها")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public int Installed { get; init; }

        public int CategoryId { get; init; }
        public int DeveloperId { get; init; }
    }
}