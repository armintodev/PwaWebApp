using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.User
{
    public record SmsVerifyDto : AuthDto, IDto
    {
        [Display(Name = "کد فعال سازی")]
        public string Code { get; init; }
    }
}