using Pwa.Domain.Account;
using Pwa.Domain.Base;
using System;

namespace Pwa.Domain.Product
{
    public class Ticket : BaseDetail
    {
        public int DeveloperId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public Developer Developer { get; private set; }

        protected Ticket()
        {

        }

        public Ticket(string title, string description, int developerId)
        {
            Title = title;
            Description = description;
            CreationDate = DateTime.Now;
            DeveloperId = developerId;
        }

        public void Edit(string description)
        {
            Description = description;
            LastEditDate = DateTime.Now;
        }
    }
}
