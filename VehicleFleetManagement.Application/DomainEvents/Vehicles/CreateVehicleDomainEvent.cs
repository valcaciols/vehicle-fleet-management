using MediatR;

namespace VehicleFleetManagement.Application.DomainEvents.Clients
{
    public class CreateVehicleDomainEvent : INotification
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public string ModelName { get; set; }
        public string ModelManufacturer { get; set; }
    }
}
