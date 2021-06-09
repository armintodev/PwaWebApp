using Pwa.Domain.Account;
using Pwa.Domain.Aggregates;
using Pwa.Domain.Base;
using System;

namespace Pwa.Domain.Product
{
    public class SourceSite : BaseDetail, ISourceSiteAggregate
    {
        public int UserId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Address { get; private set; }
        public byte[] Icons { get; private set; }
        public bool IsPwa { get; set; }

        public User User { get; private set; }

        protected SourceSite()
        {

        }

        public SourceSite(string name, string description, string address, byte[] icons, bool isPwa, int userId)
        {
            Name = name;
            Description = description;
            Address = address;
            Icons = icons;
            IsPwa = isPwa;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
            UserId = userId;
        }

        public void Edit(string name, string description, string address, byte[] icons, bool isPwa)
        {
            Name = name;
            Description = description;
            Address = address;
            Icons = icons;
            IsPwa = isPwa;
            LastEditDate = DateTime.Now;
        }
    }
}
