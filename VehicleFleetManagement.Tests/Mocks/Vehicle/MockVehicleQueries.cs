using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleFleetManagement.Application.Queries;
using VehicleFleetManagement.Application.ViewModels.Vehicle;

namespace VehicleFleetManagement.Tests.Mocks.Vehicle
{
    public class MockVehicleQueries : IVehicleQueries
    {
        public async Task<List<VehicleViewModel>> GetAllAsync(string? licensePlate, string? model, string? manufacturer)
        {
            return await Task.FromResult(new List<VehicleViewModel>
            {
                new VehicleViewModel { VehicleId = 0, LicensePlate = "SWF5456", ModelName = "Palio", ModelManufacturer = "FIAT", StatusName = "Busy" },
                new VehicleViewModel { VehicleId = 1, LicensePlate = "ASD5678", ModelName = "Civic", ModelManufacturer = "HONDA", StatusName = "Busy" },
            });
        }
    }
}
