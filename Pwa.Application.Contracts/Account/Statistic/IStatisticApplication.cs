using System.Threading.Tasks;
using WebFramework.Utilities;

namespace Pwa.Application.Contracts.Account.Statistic
{
    public interface IStatisticApplication
    {
        Task<OperationResult> Add(CreateStatisticDto createStatistic);
    }
}
