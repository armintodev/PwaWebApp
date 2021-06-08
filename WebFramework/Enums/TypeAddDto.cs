using System.ComponentModel.DataAnnotations;

namespace WebFramework.Enums
{
    public enum TypeAddDto
    {
        [Display(Name = "دستی")]
        Custom = 0,

        [Display(Name = "خودکار")]
        Auto = 1
    }
}
