using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class VehicleModelRepository : Repository<VehicleModel>, IVehicleModelRepository
    {
        private static List<VehicleModel> _vehicles = new()
        {
            new VehicleModel(0, "Palio", new VehicleManufacturer("Fiat")),
            new VehicleModel(1, "Punto", new VehicleManufacturer("Fiat")),
            new VehicleModel(2, "Civic", new VehicleManufacturer("Honda")),
            new VehicleModel(3, "Up", new VehicleManufacturer("VW"))
        };

        public VehicleModelRepository(VehicleManagerContext context) : base(context)
        {
        }

        public async Task<VehicleModel?> GetAsync(int id)
        {
           return await Task.FromResult(_vehicles.FirstOrDefault());
        }
    }
}
