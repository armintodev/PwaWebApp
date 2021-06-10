using System.ComponentModel.DataAnnotations;
using WebFramework.Infrastructure;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.Role
{
    public record CreateRoleDto : IDto
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string Name { get; init; }

        [Display(Name = "نام نمایشی")]
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string DisplayName { get; init; }
    }
}
