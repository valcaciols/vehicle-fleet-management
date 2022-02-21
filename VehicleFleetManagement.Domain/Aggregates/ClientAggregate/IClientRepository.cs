using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.ClientAggregate
{
    public interface IClientRepository: IRepository
    {
        Task<Client?> GetAsync(int id);
        Task<bool> ExistAsync(string cpf, string cnh);
        Task<bool> ExistAsync(int clientId);
        Task<List<Client>> GetAllAsync(string cpf, string name);
        Task<Client> AddAsync(Client client);
    }
}
