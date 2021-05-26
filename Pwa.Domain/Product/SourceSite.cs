using Pwa.Domain.Base;
using System;

namespace Pwa.Domain.Product
{
    public class SourceSite : BaseDetail
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Address { get; private set; }
        public string[] Icons { get; private set; }
        public bool IsPwa { get; set; }

        protected SourceSite()
        {

        }

        public SourceSite(string name, string description, string address, string[] icons, bool isPwa)
        {
            Name = name;
            Description = description;
            Address = address;
            Icons = icons;
            IsPwa = isPwa;
            CreationDate = DateTime.Now;
        }

        public void Edit(string name, string description, string address, string[] icons, bool isPwa)
        {
            Name = name;
            Description = description;
            Address = address;
            Icons = icons;
            IsPwa = isPwa;
            LastEditdate = DateTime.Now;
        }
    }
}
