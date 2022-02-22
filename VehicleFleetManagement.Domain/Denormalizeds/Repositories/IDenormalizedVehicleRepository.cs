using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Domain.Denormalizeds.Repositories
{
    public interface IDenormalizedVehicleRepository: IDenormalizedRepository<DenormalizedVehicle>
    {
        Task UpdateStatusAsync(int id, int statusId, string statusName);
    }
}
