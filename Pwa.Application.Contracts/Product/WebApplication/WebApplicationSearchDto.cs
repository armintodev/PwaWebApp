using WebFramework.Enums;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Product.WebApplication
{
    public record WebApplicationSearchDto : IDto
    {
        public string Name { get; init; }
        public string WebSiteAddress { get; init; }
        public TypeAddDto TypeAdd { get; init; }
        public StatusDto Status { get; init; }
        public int Visit { get; init; }
        public int Installed { get; init; }
    }
}
