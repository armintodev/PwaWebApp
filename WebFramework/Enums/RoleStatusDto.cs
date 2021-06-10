using System.ComponentModel.DataAnnotations;

namespace WebFramework.Enums
{
    public enum RoleStatusDto
    {
        [Display(Name = "مدیر")]
        Admin = 0,

        [Display(Name = "کاربر عادی")]
        Basic = 1,

        [Display(Name = "توسعه دهنده")]
        Developer = 2
    }
}
