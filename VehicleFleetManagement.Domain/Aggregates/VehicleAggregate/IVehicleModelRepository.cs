using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.VehicleAggregate
{
    public interface IVehicleModelRepository: IRepository
    {
        Task<VehicleModel> GetAsync(int id);
    }
}
