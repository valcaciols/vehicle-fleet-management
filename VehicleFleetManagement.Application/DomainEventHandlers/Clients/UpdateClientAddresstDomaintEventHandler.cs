using MediatR;
using VehicleFleetManagement.Application.DomainEvents.Clients;
using VehicleFleetManagement.Domain.Denormalizeds;
using VehicleFleetManagement.Domain.Denormalizeds.Repositories;

namespace VehicleFleetManagement.Application.DomainEventHandlers.Clients
{
    public class UpdateClientAddresstDomaintEventHandler : INotificationHandler<UpdateClientAddresstDomaintEvent>
    {
        private readonly IDenormalizedClientRepository _denormalizedClient;
        private readonly IDenormalizedBookingRepository _denormalizedBooking;

        public UpdateClientAddresstDomaintEventHandler(IDenormalizedClientRepository denormalizedClient, IDenormalizedBookingRepository denormalizedBooking)
        {
            _denormalizedClient = denormalizedClient;
            _denormalizedBooking = denormalizedBooking;
        }

        public async Task Handle(UpdateClientAddresstDomaintEvent notification, CancellationToken cancellationToken)
        {

            var client = new DenormalizedClient
            {
                ClientId = notification.ClientId,
                Cep = notification.Cep,
                Street = notification.Street,
                City = notification.City
            };

            await _denormalizedClient.UpdateAddressAsync(client);
        }
    }
}
