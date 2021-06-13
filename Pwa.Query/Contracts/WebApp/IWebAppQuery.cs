using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pwa.Query.Contracts.WebApp
{
    public interface IWebAppQuery
    {
        Task<List<WebAppQueryModel>> GetMostVisited();
        Task<List<WebAppQueryModel>> GetInCategory();
    }
}
