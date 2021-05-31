using Pwa.Application.Contracts.Account.User;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.SourceSite
{
    public record SourceSiteDto : IDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Address { get; init; }
        public bool IsPwa { get; init; }
        public int UserId { get; init; }
        public string UserFullName { get; init; }
        public string UserPhoneNumber { get; init; }
        //public UserDto User { get; init; }
    }
}
