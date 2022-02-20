using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.ClientAggregate
{
    public interface IClientRepository: IRepository
    {
        Task<Client> GetAsync(int id);
        Task AddAsync(Client client);
    }
}
