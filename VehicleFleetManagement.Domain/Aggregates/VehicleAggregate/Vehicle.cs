using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.VehicleAggregate
{
    public class Vehicle: Entity, IAggregateRoot
    {
        public string LicensePlate { get; private set; }
        public int VehicleModelId { get; set; }
        public VehicleModel Model { get; private set; }
        public VehicleStatus Status { get; private set; }

        public Vehicle(string licensePlate, VehicleModel model)
        {
            LicensePlate = licensePlate;
            Model = model;
            VehicleModelId = model.Id;
            Status = VehicleStatus.Available;
        }

        public void ChangeStatus(VehicleStatus status)
        {
            Status = status;
        }
    }
}
