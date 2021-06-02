using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.User
{
    public record LoginDto : IDto
    {
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string PhoneNumber { get; init; }
    }
}
