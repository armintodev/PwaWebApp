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
        public int AddressId { get; private set; }
        public int StatisticId { get; private set; }
        public string NationalCode { get; private set; }
        public string FullName { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public string Country { get; private set; }

        public string Code { get; private set; }
        public Status Status { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastEditDate { get; private set; }

        public Statistic Statistic { get; private set; }
        public ICollection<WebApplication> WebApplications { get; private set; }
        public ICollection<Ticket> Tickets { get; private set; }

        protected Developer()
        {

        }

        public Developer(string email, int statisticId)
        {
            Email = email;
            CreationDate = DateTime.Now;
            StatisticId = statisticId;
            DeActive();
            WebApplications = new List<WebApplication>();
            Tickets = new List<Ticket>();
        }

        public Developer(string email, string userName, string fullName, string nationalCode, string phoneNumber, string city, string province, string country, int statisticId)
        {
            Email = email;
            UserName = userName;
            FullName = fullName;
            NationalCode = nationalCode;
            PhoneNumber = phoneNumber;
            City = city;
            Province = province;
            Country = country;
            CreationDate = DateTime.Now;
            StatisticId = statisticId;
            DeActive();
            WebApplications = new List<WebApplication>();
            Tickets = new List<Ticket>();
        }

        public void Edit(string fullName, string nationalCode, string city, string province, string country)
        {
            FullName = fullName;
            NationalCode = nationalCode;
            City = city;
            Province = province;
            Country = country;
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
    }
}
