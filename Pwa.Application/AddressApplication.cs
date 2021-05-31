using Pwa.Application.Contracts.Account.Address;
using Pwa.Domain.Account;

namespace Pwa.Application
{
    public class AddressApplication : IAddressApplication
    {
        private readonly IAddressRepository _address;
        public AddressApplication(IAddressRepository address)
        {
            _address = address;
        }
    }
}
