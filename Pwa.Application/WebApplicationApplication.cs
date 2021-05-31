using Pwa.Application.Contracts.Product.WebApplication;
using Pwa.Domain.Product;

namespace Pwa.Application
{
    public class WebApplicationApplication : IWebApplicationApplication
    {
        private readonly IWebApplicationRepository _webApplication;
        public WebApplicationApplication(IWebApplicationRepository webApplication)
        {
            _webApplication = webApplication;
        }
    }
}
