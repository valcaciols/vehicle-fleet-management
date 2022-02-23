using MediatR;

namespace VehicleFleetManagement.Application.DomainEvents.Booking
{
    public class UpdateBookingExpectedDateDomainEvent : INotification
    {
        public int BookingId { get; set; }
        public DateTime? DateExpectedReturn { get; set; }
        public DateTime? DateExpectedWithdrawn { get; set; }
    }
}
