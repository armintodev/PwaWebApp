using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pwa.Query.Contracts.WebApp
{
    public interface IWebAppQuery
    {
        Task<List<WebAppQueryModel>> GetBests();
        Task<List<WebAppQueryModel>> GetGames();
        Task<List<WebAppQueryModel>> GetMostVisit();
    }
}
