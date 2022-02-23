using MediatR;
using VehicleFleetManagement.Application.DomainEvents.Booking;
using VehicleFleetManagement.Domain.Aggregates.BookingAggregate;
using VehicleFleetManagement.Domain.Denormalizeds.Repositories;

namespace VehicleFleetManagement.Application.DomainEventHandlers.Booking
{
    public class UpdateBookingWithdrawnDomainEventHandler : INotificationHandler<UpdateBookingWithdrawnDomainEvent>
    {
        private readonly IDenormalizedBookingRepository _denormalizedBooking;
        private readonly IBookingRepository _bookingRepository;

        public UpdateBookingWithdrawnDomainEventHandler(IDenormalizedBookingRepository denormalizedBooking, IBookingRepository bookingRepository)
        {
            _denormalizedBooking = denormalizedBooking;
            _bookingRepository = bookingRepository;
        }

        public async Task Handle(UpdateBookingWithdrawnDomainEvent notification, CancellationToken cancellationToken)
        {
            await _bookingRepository.UpdateDateWithdrawnAsync(
                    notification.BookingId,
                    notification.DateWithdrawn);

            await _denormalizedBooking.UpdateDateWithdrawnAsync(
                    notification.BookingId,
                    notification.DateWithdrawn);
        }
    }
}
