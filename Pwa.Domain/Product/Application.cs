using Pwa.Domain.Base;
using System;
using WebFramework.Enums;

namespace Pwa.Domain.Product
{
    public class Application : BaseDetail
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string WebSiteAddress { get; private set; }
        public string[] Icons { get; private set; }
        public TypeAdd TypeAdd { get; private set; }
        public Status Status { get; private set; }
        //public int Quantity { get; private set; }
        public int Visit { get; private set; }
        public int Installed { get; private set; }

        protected Application()
        {

        }

        public Application(string name, string description, string websiteAddress,
            string[] icons, TypeAdd typeAdd, Status status/*, int quantity*/)
        {
            Name = name;
            Description = description;
            WebSiteAddress = websiteAddress;
            Icons = icons;
            TypeAdd = typeAdd;
            Status = status;
            //Quantity = quantity;
            CreationDate = DateTime.Now;
        }

        public void Edit(string name, string description, string[] icons, Status status)
        {
            Name = name;
            Description = description;
            Icons = icons;
            Status = status;
            LastEditdate = DateTime.Now;
        }

        public void IncreaseVisit()
        {
            Visit += 1;
        }
        public void IncreaseInstalled()
        {
            Installed += 1;
        }
    }
}
