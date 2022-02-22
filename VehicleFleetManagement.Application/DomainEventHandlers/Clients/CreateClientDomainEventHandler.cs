using MediatR;
using VehicleFleetManagement.Application.DomainEvents.Clients;

namespace VehicleFleetManagement.Application.DomainEventHandlers.Clients
{
    public class CreateClientDomainEventHandler : INotificationHandler<CreateClientDomainEvent>
    {
        public async Task Handle(CreateClientDomainEvent notification, CancellationToken cancellationToken)
        {

            await Task.CompletedTask;
        }
    }
}
