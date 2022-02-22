using MediatR;
using VehicleFleetManagement.Application.DomainEvents.Clients;
using VehicleFleetManagement.Domain.Denormalizeds;
using VehicleFleetManagement.Domain.Denormalizeds.Repositories;

namespace VehicleFleetManagement.Application.DomainEventHandlers.Booking
{
    public class CreateBookingDomainEventHandler : INotificationHandler<CreateBookingDomainEvent>
    {
        private readonly IDenormalizedBookingRepository _denormalizedBooking;

        public CreateBookingDomainEventHandler(IDenormalizedBookingRepository denormalizedBooking)
        {
            _denormalizedBooking = denormalizedBooking;
        }

        public async Task Handle(CreateBookingDomainEvent notification, CancellationToken cancellationToken)
        {
            var booking = new DenormalizedBooking
            {
                BookingId = notification.BookingId,
                ClientId = notification.ClientId,
                Cpf = notification.Cpf,
                VehicleId = notification.VehicleId,
                VehicleModel = notification.VehicleModel,
                ClientName = notification.ClientName,
                LicensePlate = notification.LicensePlate,
                DateCreated = notification.DateCreated,
                DateExpectedReturn = notification.DateExpectedReturn,
                DateWithdrawn = notification.DateWithdrawn
            };

            await _denormalizedBooking.AddAsync(booking);
        }
    }
}
