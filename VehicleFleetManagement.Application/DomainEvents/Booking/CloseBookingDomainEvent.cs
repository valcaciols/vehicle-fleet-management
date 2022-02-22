using MediatR;

namespace VehicleFleetManagement.Application.DomainEvents.Clients
{
    public class CloseBookingDomainEvent : INotification
    {
        public int BookingId { get; set; }
        public DateTime DateReturn { get; set; }
    }
}
