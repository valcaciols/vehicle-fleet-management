using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private List<Address> _addresses = new ();
        public async Task<Address> AddAsync(Address address)
        {
            _addresses.Add(address);
            return await Task.FromResult(address);
        }

        public async Task UpdateAddressAsync(Address address)
        {
            var addresses = _addresses.FirstOrDefault(w => w.ClientId == address.ClientId);

            if (addresses == null)
                return;

            address.Change(address.Street, address.City, address.Cep);

            await Task.CompletedTask;
        }
    }
}
