using Microsoft.AspNetCore.Identity;
using System;
using WebFramework.Enums;

namespace Pwa.Domain.Account
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; private set; }
        public Status Status { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastEditDate { get; private set; }

        protected User()
        {

        }

        public User(string phone)
        {
            PhoneNumber = phone;
            CreationDate = DateTime.Now;
        }

        public void Edit(string fullName = null, string email = null)
        {
            FullName = fullName;
            Email = email;
            LastEditDate = DateTime.Now;
        }

        public void Active()
        {
            Status = Status.Active;
        }

        public void DeActive()
        {
            Status = Status.DeActive;
        }

        public void ChangePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
