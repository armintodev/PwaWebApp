using System.Collections.Generic;
using System.Threading.Tasks;
using WebFramework.Infrastructure;

namespace Pwa.Application.Contracts.Account.Address
{
    public interface IAddressApplication
    {
        Task<List<AddressDto>> List();
        Task<List<string>> Cities();
        Task<List<string>> Provinces();
        Task<List<string>> Countries();
    }
}
