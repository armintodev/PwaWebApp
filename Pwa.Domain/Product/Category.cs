using Pwa.Domain.Base;
using System;
using System.Collections.Generic;
using WebFramework.Domain;

namespace Pwa.Domain.Product
{
    public class Category : BaseDetail, IEntity
    {
        public string Title { get; private set; }

        public ICollection<WebApplication> WebApplications { get; private set; }

        protected Category()
        {

        }

        public Category(string title)
        {
            Title = title;
            WebApplications = new List<WebApplication>();
            CreationDate = DateTime.Now;
        }

        public void Edit(string title)
        {
            Title = title;
            LastEditDate = DateTime.Now;
        }
    }
}
