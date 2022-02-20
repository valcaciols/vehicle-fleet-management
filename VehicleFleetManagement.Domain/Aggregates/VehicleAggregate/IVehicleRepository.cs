using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.VehicleAggregate
{
    public interface IVehicleRepository: IRepository
    {
        Task<Vehicle> GetAsync(int id);
        Task<Vehicle> AddAsync(Vehicle vehicle);
        Task<Vehicle> UpdateStatusAsync(int id, VehicleStatus status);
    }
}
