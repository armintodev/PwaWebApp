using Pwa.Domain.Base;
using System;

namespace Pwa.Domain.Account
{
    public class Address : BaseEntity
    {
        public string City { get; private set; }
        public string Province { get; private set; }
        public string Country { get; private set; }
        public DateTime CreationDate { get; private set; }

        protected Address()
        {

        }

        public Address(string city, string province, string country)
        {
            City = city;
            Province = province;
            Country = country;
            CreationDate = DateTime.Now;
        }
    }
}
