using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private List<VehicleModel> _vehicles = new()
        {
            new VehicleModel("Palio", new VehicleManufacturer("Fiat")),
            new VehicleModel("Civic", new VehicleManufacturer("Honda"))
        };
        public async Task<VehicleModel?> GetAsync(int id)
        {
           return await Task.FromResult(_vehicles.FirstOrDefault());
        }
    }
}
