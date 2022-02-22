using MediatR;
using VehicleFleetManagement.Application.DomainEvents.Clients;

namespace VehicleFleetManagement.Application.DomainEventHandlers.Clients
{
    public class CreateVehicleDomainEventHandler : INotificationHandler<CreateVehicleDomainEvent>
    {
        public async Task Handle(CreateVehicleDomainEvent notification, CancellationToken cancellationToken)
        {

            await Task.CompletedTask;
        }
    }
}
