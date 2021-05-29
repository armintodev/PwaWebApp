using Microsoft.AspNetCore.Identity;
using Pwa.Domain.Aggregates;
using Pwa.Domain.Product;
using System;
using System.Collections.Generic;
using WebFramework.Enums;

namespace Pwa.Domain.Account
{
    public class User : IdentityUser<int>, IUserAggregate
    {
        public string FullName { get; private set; }
        public Status Status { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastEditDate { get; private set; }

        public ICollection<Comment> Comments { get; private set; }
        public ICollection<SourceSite> SourceSites { get; private set; }

        protected User()
        {

        }

        public User(string phone)
        {
            PhoneNumber = phone;
            Status = Status.DeActive;
            CreationDate = DateTime.Now;
            Comments = new List<Comment>();
            SourceSites = new List<SourceSite>();
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
