using System.ComponentModel.DataAnnotations;
using WebFramework.Enums;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.Comment
{
    public record CommentDto : IDto
    {
        [Display(Name = "آی دی")]
        public int Id { get; init; }

        [Display(Name = "توضیحات")]
        public string Description { get; init; }

        public bool IsDeveloper { get; init; }

        [Display(Name = "وضعیت")]
        public StatusDto Status { get; init; }
        public int UserId { get; init; }
        public int WebApplicationId { get; init; }

        [Display(Name = "کاربر")]
        public string UserInfo { get; init; }

        [Display(Name = "وب اپلیکیشن")]
        public string WebAppName { get; init; }

        [Display(Name = "آدرس")]
        public string WebAppAddress { get; init; }

        public string CreationDate { get; init; }
    }
}
