using Microsoft.AspNetCore.Identity;
using Pwa.Domain.Aggregates;

namespace Pwa.Domain.Account
{
    public class Role : IdentityRole<int>, IRoleAggregate
    {
        public Role(string name)
        {
            Name = name;
        }
    }
}
