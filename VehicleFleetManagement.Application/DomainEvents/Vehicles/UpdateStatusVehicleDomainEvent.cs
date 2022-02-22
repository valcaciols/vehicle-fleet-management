using MediatR;
using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Application.DomainEvents.Clients
{
    public class UpdateStatusVehicleDomainEvent : INotification
    {
        public int VehicleId { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
