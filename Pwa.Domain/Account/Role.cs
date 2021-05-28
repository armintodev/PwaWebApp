using Microsoft.AspNetCore.Identity;
using WebFramework.Domain;

namespace Pwa.Domain.Account
{
    public class Role : IdentityRole<int>, IEntity
    {
    }
}
