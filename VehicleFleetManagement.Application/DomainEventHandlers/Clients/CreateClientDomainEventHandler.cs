using MediatR;
using VehicleFleetManagement.Application.DomainEvents.Clients;
using VehicleFleetManagement.Domain.Denormalizeds;
using VehicleFleetManagement.Domain.Denormalizeds.Repositories;

namespace VehicleFleetManagement.Application.DomainEventHandlers.Clients
{
    public class CreateClientDomainEventHandler : INotificationHandler<CreateClientDomainEvent>
    {
        private readonly IDenormalizedClientRepository _denormalizedClient;

        public CreateClientDomainEventHandler(IDenormalizedClientRepository denormalizedClient)
        {
            _denormalizedClient = denormalizedClient;
        }

        public async Task Handle(CreateClientDomainEvent notification, CancellationToken cancellationToken)
        {
            var client = new DenormalizedClient
            {
                ClientId = notification.ClientId,
                Name = notification.Name,
                BirthDate = notification.BirthDate,
                Cnh = notification.Cnh,
                Cpf = notification.Cpf,
                Cep = notification.Cep,
                Street = notification.Street,
                City = notification.City
            };

            await _denormalizedClient.AddAsync(client);
        }
    }
}
