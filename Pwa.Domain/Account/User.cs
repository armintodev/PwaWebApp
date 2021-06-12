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
        public string Code { get; private set; }
        public Status Status { get; private set; }
        public RoleStatus RoleStatus { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastEditDate { get; private set; }

        public Developer Developer { get; private set; }
        public ICollection<Statistic> Statistics { get; private set; }
        public ICollection<Comment> Comments { get; private set; }

        protected User()
        {

        }

        public User(string phone, string fullName = "")
        {
            FullName = fullName;
            PhoneNumber = phone;
            UserName = phone;
            RoleStatus = RoleStatus.Basic;
            DeActive();
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
            Statistics = new List<Statistic>();
            Comments = new List<Comment>();
        }

        public User(string email, string userName, string phoneNumber, string fullName)
        {
            FullName = fullName;
            Email = email;
            UserName = userName;
            PhoneNumber = phoneNumber;
            RoleStatus = RoleStatus.Developer;
            DeActive();
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
            Statistics = new List<Statistic>();
        }

        public void Edit(string fullName)
        {
            FullName = fullName;
            LastEditDate = DateTime.Now;
            DeActive();
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
            DeActive();
            LastEditDate = DateTime.Now;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            DeActive();
            LastEditDate = DateTime.Now;
        }

        public void SmsCode(string code)
        {
            Code = code;
            LastEditDate = DateTime.Now;
        }

        public void SetRoleStatus(RoleStatus role)
        {
            RoleStatus = role;
        }
    }
}
