using Pwa.Domain.Aggregates;
using Pwa.Domain.Base;
using Pwa.Domain.Product;
using System;
using System.Collections.Generic;
using WebFramework.Enums;

namespace Pwa.Domain.Account
{
    public class Developer : BaseDetail, IDeveloperAggregate
    {
        public string NationalCode { get; private set; }
        public string City { get; private set; }
        public string ProfileUrl { get; private set; }
        public string Province { get; private set; }
        public string Country { get; private set; }
        public Status Status { get; private set; }

        public User User { get; private set; }
        public ICollection<Statistic> Statistics { get; private set; }
        public ICollection<WebApplication> WebApplications { get; private set; }
        public ICollection<Ticket> Tickets { get; private set; }

        protected Developer()
        {

        }

        public Developer(int userId, string nationalCode, string city, string province, string country, string profileUrl)
        {
            Id = userId;
            NationalCode = nationalCode;
            City = city;
            Province = province;
            Country = country;
            ProfileUrl = profileUrl;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
            Statistics = new List<Statistic>();
            WebApplications = new List<WebApplication>();
            Tickets = new List<Ticket>();
        }

        public void Edit(string fullName, string nationalCode, string city, string province, string country, string profileUrl)
        {
            User.Edit(fullName);
            NationalCode = nationalCode;
            City = city;
            Province = province;
            Country = country;
            ProfileUrl = profileUrl;
            LastEditDate = DateTime.Now;
        }
    }
}
