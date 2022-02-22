using MediatR;
using VehicleFleetManagement.Application.DomainEvents.Clients;

namespace VehicleFleetManagement.Application.DomainEventHandlers.Clients
{
    public class UpdateClientAddresstDomaintEventHandler : INotificationHandler<UpdateClientAddresstDomaintEvent>
    {
        public async Task Handle(UpdateClientAddresstDomaintEvent notification, CancellationToken cancellationToken)
        {

            await Task.CompletedTask;
        }
    }
}
