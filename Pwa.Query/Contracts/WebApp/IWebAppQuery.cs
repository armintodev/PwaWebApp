using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Domain;

namespace Pwa.Query.Contracts.WebApp
{
    public interface IWebAppQuery
    {
        Task<List<WebAppQueryModel>> GetBests();
        Task<List<WebAppQueryModel>> GetGames();
        Task<List<WebAppQueryModel>> GetMostVisit();
        Task<WebAppQueryModel> GetSingle(int id);
        Task<List<WebAppQueryModel>> RelatedApps(int id);
        Task<ResponseDto<WebAppQueryModel>> List(ResponseDto<WebAppQueryModel> response);
    }
}
