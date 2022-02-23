using MediatR;

namespace VehicleFleetManagement.Application.DomainEvents.Booking
{
    public class UpdateBookingWithdrawnDomainEvent : INotification
    {
        public int BookingId { get; set; }
        public int VehicleId { get; set; }
        public DateTime DateWithdrawn { get; set; }
    }
}
