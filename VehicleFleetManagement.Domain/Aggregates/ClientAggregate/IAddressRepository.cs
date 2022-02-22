using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.ClientAggregate
{
    public interface IAddressRepository: IRepository
    {
        Task<Address?> GetByClientIdAsync(int clientId);

        Task UpdateAddressAsync(Address address);
        Task<Address> AddAsync(Address address);
    }
}
