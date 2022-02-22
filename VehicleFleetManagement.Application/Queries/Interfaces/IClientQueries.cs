using VehicleFleetManagement.Application.ViewModels.Client;

namespace VehicleFleetManagement.Application.Queries
{
    public interface IClientQueries : IQueries
    {
        Task<List<ClientViewModel>> GetAllAsync(string? cpf, string? name);
    }
}
