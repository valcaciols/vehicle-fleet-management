using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Tests.Mocks.Vehicle
{
    public class MockVehicleModelRepository : IVehicleModelRepository
    {
        private readonly List<VehicleModel> _vehicleModels = new List<VehicleModel>
        {
            new VehicleModel(0, "FIAT"),
            new VehicleModel(1, "HONDA")
        };

        public async Task<VehicleModel?> GetAsync(int id)
        {
            return await Task.FromResult(_vehicleModels.Find(w => w.Id == id));
        }
    }
}
