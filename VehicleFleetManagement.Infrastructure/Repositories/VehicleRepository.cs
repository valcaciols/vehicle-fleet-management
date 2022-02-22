using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private static List<Vehicle> _vehicles = new()
        {
            new Vehicle("JXO5050", 0),
            new Vehicle("ASC5146", 1),
            new Vehicle("WEF9874", 2),
            new Vehicle("HGD6547", 3),
        };

        public VehicleRepository(VehicleManagerContext context) : base(context)
        {
        }

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
