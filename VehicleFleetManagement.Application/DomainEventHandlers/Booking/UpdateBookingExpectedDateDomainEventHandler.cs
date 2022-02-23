using MediatR;
using VehicleFleetManagement.Application.DomainEvents.Booking;
using VehicleFleetManagement.Domain.Denormalizeds;
using VehicleFleetManagement.Domain.Denormalizeds.Repositories;

namespace VehicleFleetManagement.Application.DomainEventHandlers.Booking
{
    public class UpdateBookingExpectedDateDomainEventHandler : INotificationHandler<UpdateBookingExpectedDateDomainEvent>
    {
        private readonly IDenormalizedBookingRepository _denormalizedBooking;

        public UpdateBookingExpectedDateDomainEventHandler(IDenormalizedBookingRepository denormalizedBooking)
        {
            _denormalizedBooking = denormalizedBooking;
        }

        public async Task Handle(UpdateBookingExpectedDateDomainEvent notification, CancellationToken cancellationToken)
        {
            await _denormalizedBooking.UpdateExpectedDateAsync(
                notification.BookingId,
                notification.DateExpectedWithdrawn,
                notification.DateExpectedReturn);
        }
    }
}
