using Pwa.Application.Contracts.Account.Developer;
using Pwa.Application.Contracts.Product.Category;
using WebFramework.Enums;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.WebApplication
{
    public record WebApplicationDto : IDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string WebSiteAddress { get; init; }
        public byte[] Icons { get; init; }
        public TypeAddDto TypeAdd { get; init; }
        public StatusDto Status { get; init; }
        public int Visit { get; init; }
        public int Installed { get; init; }
        public int CategoryId { get; init; }
        public int DeveloperId { get; init; }
        //public CategoryDto Category { get; init; }
        //public DeveloperDto Developer { get; init; }
    }
}
