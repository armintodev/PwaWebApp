using Microsoft.AspNetCore.Identity;
using Pwa.Domain.Aggregates;
using Pwa.Domain.Product;
using System;
using System.Collections.Generic;
using WebFramework.Enums;

namespace Pwa.Domain.Account
{
    public class Developer : IdentityUser<int>, IDeveloperAggregate
    {
        public string NationalCode { get; private set; }
        public string FullName { get; private set; }
        public string City { get; private set; }
        public string ProfileUrl { get; private set; }
        public string Province { get; private set; }
        public string Country { get; private set; }
        public string Code { get; private set; }
        public Status Status { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastEditDate { get; private set; }

        public ICollection<Statistic> Statistics { get; private set; }
        public ICollection<WebApplication> WebApplications { get; private set; }
        public ICollection<Ticket> Tickets { get; private set; }

        protected Developer()
        {

        }

        public Developer(string email)
        {
            Email = email;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
            DeActive();
            Statistics = new List<Statistic>();
            WebApplications = new List<WebApplication>();
            Tickets = new List<Ticket>();
        }

        public Developer(string email, string userName, string fullName, string nationalCode, string phoneNumber, string city, string province, string country, string profileUrl)
        {
            Email = email;
            UserName = userName;
            FullName = fullName;
            NationalCode = nationalCode;
            PhoneNumber = phoneNumber;
            City = city;
            Province = province;
            Country = country;
            ProfileUrl = profileUrl;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
            DeActive();
            Statistics = new List<Statistic>();
            WebApplications = new List<WebApplication>();
            Tickets = new List<Ticket>();
        }

        public void Edit(string fullName, string nationalCode, string city, string province, string country, string profileUrl)
        {
            FullName = fullName;
            NationalCode = nationalCode;
            City = city;
            Province = province;
            Country = country;
            ProfileUrl = profileUrl;
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
            LastEditDate = DateTime.Now;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            LastEditDate = DateTime.Now;
        }

        public void SmsCode(string code)
        {
            Code = code;
            LastEditDate = DateTime.Now;
        }
    }
}
