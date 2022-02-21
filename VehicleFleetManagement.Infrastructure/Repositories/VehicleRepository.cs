using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private List<Vehicle> _vehicles = new()
        {
            new Vehicle("JXO5050", 0, new VehicleModel("Palio", new VehicleManufacturer("Fiat")))
        };

        public async Task<Vehicle> AddAsync(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
            return await Task.FromResult(vehicle);
        }

        public async Task<bool> ExistAsync(string licencePlate)
        {
            return await Task.FromResult(false);
        }

        public async Task<Vehicle?> GetAsync(int id)
        {
           var vehicle = _vehicles.Find(x => x.Id == id);
           return await Task.FromResult(vehicle);
        }

        public async Task UpdateStatusAsync(int id, VehicleStatus status)
        {
            var vehicle = _vehicles.Find(x => x.Id == id);

            if(vehicle != null)
                vehicle.ChangeStatus(status);

            await Task.CompletedTask;
        }
    }
}
