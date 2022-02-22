using MediatR;
using VehicleFleetManagement.Application.DomainEvents.Clients;

namespace VehicleFleetManagement.Application.DomainEventHandlers.Booking
{
    public class CreateBookingDomainEventHandler : INotificationHandler<CreateBookingDomainEvent>
    {
        public async Task Handle(CreateBookingDomainEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
