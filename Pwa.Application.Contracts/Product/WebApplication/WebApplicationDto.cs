using Pwa.Application.Contracts.Account.Developer;
using Pwa.Application.Contracts.Product.Category;
using System.ComponentModel.DataAnnotations;
using WebFramework.Enums;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.WebApplication
{
    public record WebApplicationDto : IDto
    {
        [Display(Name = "آی دی")]
        public int Id { get; init; }

        [Display(Name = "نام")]
        public string Name { get; init; }

        [Display(Name = "توضیحات")]
        public string Description { get; init; }

        [Display(Name = "آدرس وب سایت")]
        public string WebSiteAddress { get; init; }

        [Display(Name = "نوع اضافه شده")]
        public TypeAddDto TypeAdd { get; init; }

        [Display(Name = "وضعیت")]
        public StatusDto Status { get; init; }

        [Display(Name = "بازدید")]
        public int Visit { get; init; }

        [Display(Name = "دریافت شده")]
        public int Installed { get; init; }

        [Display(Name = "تاریخ ایجاد محصول")]
        public string CreationDate { get; init; }

        public int CategoryId { get; init; }
        public int DeveloperId { get; init; }
        //public CategoryDto Category { get; init; }
        //public DeveloperDto Developer { get; init; }
    }
}
