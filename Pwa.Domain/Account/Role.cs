using System;
using Microsoft.AspNetCore.Identity;
using Pwa.Domain.Aggregates;

namespace Pwa.Domain.Account
{
    public class Role : IdentityRole<int>, IRoleAggregate
    {
        public string DisplayName { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastEditDate { get; private set; }
        public Role(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
        }

        public void Edit(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
            LastEditDate = DateTime.Now;
        }
    }
}
