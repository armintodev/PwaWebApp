using Pwa.Domain.Account;
using Pwa.Domain.Base;
using System;
using System.Collections.Generic;
using WebFramework.Domain;
using WebFramework.Enums;

namespace Pwa.Domain.Product
{
    public class WebApplication : BaseDetail, IEntity
    {
        public int CategoryId { get; private set; }
        public int DeveloperId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string WebSiteAddress { get; private set; }
        public byte[] Icons { get; private set; }
        public TypeAdd TypeAdd { get; private set; }
        public Status Status { get; private set; }
        public int Visit { get; private set; }
        public int Installed { get; private set; }

        public Category Category { get; private set; }
        public Developer Developer { get; private set; }
        public ICollection<Comment> Comments { get; private set; }


        protected WebApplication()
        {

        }

        public WebApplication(string name, string description, string websiteAddress,
            byte[] icons, TypeAdd typeAdd, Status status, int categoryId, int developerId)
        {
            Name = name;
            Description = description;
            WebSiteAddress = websiteAddress;
            Icons = icons;
            TypeAdd = typeAdd;
            Status = status;
            CreationDate = DateTime.Now;
            CategoryId = categoryId;
            DeveloperId = developerId;
            Comments = new List<Comment>();
        }

        public void Edit(string name, string description, byte[] icons, Status status)
        {
            Name = name;
            Description = description;
            Icons = icons;
            Status = status;
            LastEditDate = DateTime.Now;
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
