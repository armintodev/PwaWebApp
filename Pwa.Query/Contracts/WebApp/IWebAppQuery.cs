using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pwa.Query.Contracts.WebApp
{
    public interface IWebAppQuery
    {
        Task<List<WebAppQueryModel>> GetBests();
        Task<List<WebAppQueryModel>> GetGames();
        Task<List<WebAppQueryModel>> GetMostVisit();
        Task<WebAppQueryModel> GetSingle(int id);
        Task<List<WebAppQueryModel>> RelatedApps(int id);
    }
}
