using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.VehicleAggregate
{
    public interface IVehicleRepository: IRepository
    {
        Task<Vehicle?> GetAsync(int id);
        Task<bool> ExistAsync(string licencePlate);
        Task<Vehicle> AddAsync(Vehicle vehicle);
        Task UpdateStatusAsync(int id, int statusId);
    }
}
