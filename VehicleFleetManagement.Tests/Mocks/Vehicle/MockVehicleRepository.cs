using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Tests.Mocks.Vehicle
{
    public class MockVehicleRepository : IVehicleRepository
    {
        private readonly List<Domain.Aggregates.VehicleAggregate.Vehicle> _vehicles = new List<Domain.Aggregates.VehicleAggregate.Vehicle>
        {
            new(0, "JWO5587", 0),
            new(1, "HCA5678", 1)
        };

        public async Task<Domain.Aggregates.VehicleAggregate.Vehicle> AddAsync(Domain.Aggregates.VehicleAggregate.Vehicle vehicle)
        {
            vehicle.Id = _vehicles.Count + 1;
            _vehicles.Add(vehicle);
            return await Task.FromResult(vehicle);
        }

        public async Task<bool> ExistAsync(string licencePlate)
        {
            return await Task.FromResult(_vehicles.Any(w => w.LicensePlate == licencePlate));
        }

        public async Task<Domain.Aggregates.VehicleAggregate.Vehicle?> GetAsync(int id)
        {
            return await Task.FromResult(_vehicles.Find(w => w.Id == id));
        }

        public Task UpdateStatusAsync(int id, int statusId)
        {
            var vehicle = _vehicles.Find(w => w.Id == id);

            if (vehicle == null)
                return Task.CompletedTask;

            vehicle.ChangeStatus(GetVehicleStatusId(statusId));

            return Task.CompletedTask;
        }

        private VehicleStatus GetVehicleStatusId(int statusId)
        {
            if((int) VehicleStatus.Busy == statusId)
                return VehicleStatus.Busy;

            return VehicleStatus.Available;
        }
    }
}
