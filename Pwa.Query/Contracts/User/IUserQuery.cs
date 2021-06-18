using System.Threading.Tasks;

namespace Pwa.Query.Contracts.User
{
    public interface IUserQuery
    {
        Task<UserQueryModel> Info();
    }
}
