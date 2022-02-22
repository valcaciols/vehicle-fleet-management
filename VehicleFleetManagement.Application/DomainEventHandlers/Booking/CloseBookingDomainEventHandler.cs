using MediatR;
using VehicleFleetManagement.Application.DomainEvents.Clients;
using VehicleFleetManagement.Domain.Denormalizeds;
using VehicleFleetManagement.Domain.Denormalizeds.Repositories;

namespace VehicleFleetManagement.Application.DomainEventHandlers.Booking
{
    public class CloseBookingDomainEventHandler : INotificationHandler<CloseBookingDomainEvent>
    {
        private readonly IDenormalizedBookingRepository _denormalizedBooking;

        public CloseBookingDomainEventHandler(IDenormalizedBookingRepository denormalizedBooking)
        {
            _denormalizedBooking = denormalizedBooking;
        }

        public async Task Handle(CloseBookingDomainEvent notification, CancellationToken cancellationToken)
        {
            var booking = new DenormalizedBooking
            {
                BookingId = notification.BookingId,
                DateReturn = notification.DateReturn
            };

            await _denormalizedBooking.UpdateDateReturnAsync(booking);
        }
    }
}
