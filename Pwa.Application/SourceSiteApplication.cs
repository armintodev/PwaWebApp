using Pwa.Application.Contracts.Product.SourceSite;
using Pwa.Domain.Product;

namespace Pwa.Application
{
    public class SourceSiteApplication : ISourceSiteApplication
    {
        private readonly ISourceSiteRepository _sourceSite;
        public SourceSiteApplication(ISourceSiteRepository sourceSite)
        {
            _sourceSite = sourceSite;
        }
    }
}
