using WebFramework.Enums;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.Comment
{
    public record CommentDto : IDto
    {
        public int Id { get; init; }
        public string Description { get; init; }
        public bool IsDeveloper { get; init; }
        public StatusDto Status { get; init; }
        public int UserId { get; init; }
        public int WebApplicationId { get; init; }
        public string UserFullName { get; init; }
        public string UserPhoneNumber { get; init; }
        public string WebAppName { get; init; }
        public string WebAppAddress { get; init; }

        //public WebApplicationDto WebApplication { get; init; }
    }
}
