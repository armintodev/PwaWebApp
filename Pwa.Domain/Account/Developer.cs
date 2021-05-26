using Microsoft.AspNetCore.Identity;
using System;
using WebFramework.Enums;

namespace Pwa.Domain.Account
{
    public class Developer : IdentityUser<string>
    {
        public string NationalCode { get; private set; }
        public string FullName { get; private set; }
        public Status Status { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public string Country { get; private set; }
        public string Address { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastEditdate { get; private set; }
    }
}
