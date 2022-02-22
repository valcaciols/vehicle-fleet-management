using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.VehicleAggregate
{
    public class Vehicle: Entity, IAggregateRoot
    {
        public string LicensePlate { get; private set; }
        public int VehicleModelId { get; set; }
        public VehicleModel? VehicleModel { get; private set; }
        public VehicleStatus Status { get; private set; }

        public Vehicle()
        {

        }

        public Vehicle(string licensePlate, int vehicleModelId, VehicleModel? vehicleModel = null)
        {
            LicensePlate = licensePlate;
            VehicleModelId = vehicleModelId;
            VehicleModel = vehicleModel;
            Status = VehicleStatus.Available;
        }

        public bool IsAvailable()
        {
            return Status == VehicleStatus.Available;
        }

        public void ChangeStatus(VehicleStatus status)
        {
            Status = status;
        }
    }
}
