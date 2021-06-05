using System.ComponentModel.DataAnnotations;

namespace WebFramework.Enums
{
    public enum StatusDto
    {
        [Display(Name = "فعال")] Active = 0,
        [Display(Name = "غیر فعال")] DeActive = 1,
        [Display(Name = "تایید شده")] Accepted = 10,
        [Display(Name = "رد شده")] Rejected = 11,
        [Display(Name = "درحال بررسی")] Pending = 12
    }
}
