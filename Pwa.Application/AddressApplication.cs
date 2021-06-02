using Microsoft.EntityFrameworkCore;
using Pwa.Application.Contracts.Account.Address;
using Pwa.Domain.Account;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Infrastructure;

namespace Pwa.Application
{
    public class AddressApplication : IAddressApplication
    {
        private readonly IAddressRepository _address;
        public AddressApplication(IAddressRepository address)
        {
            _address = address;
        }

        public async Task<List<string>> Cities()
        {
            return await _address.TableNoTracking.Select(_ => _.City).ToListAsync();
        }

        public async Task<List<string>> Countries()
        {
            return await _address.TableNoTracking.Select(_ => _.Country).ToListAsync();
        }

        public async Task<List<AddressDto>> List()
        {
            var addresses = _address.TableNoTracking.Select(_ => new AddressDto
            {
                Id = _.Id,
                City = _.City,
                Province = _.Province,
                Country = _.Country,
                CreationDate = _.CreationDate.ToFarsi()
            });

            return await addresses.Distinct().ToListAsync();
        }

        public async Task<List<string>> Provinces()
        {
            return await _address.TableNoTracking.Select(_ => _.Province).ToListAsync();
        }
    }
}
