using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private List<Address> _addresses = new()
        {
            new Address(0, "Avenida Torquato", "Manaus", 69092045)
        };

        public async Task<Address> AddAsync(Address address)
        {
            _addresses.Add(address);
            return await Task.FromResult(address);
        }

        public async Task<Address?> GetByClientIdAsync(int clientId)
        {
            return await Task.FromResult(_addresses.FirstOrDefault());
        }

        public async Task<Address> UpdateAddressAsync(Address address)
        {
            var addresses = _addresses.First(w => w.ClientId == address.ClientId);

            addresses.Change(address.Street, address.City, address.Cep);

            return await Task.FromResult(addresses);
        }
    }
}
