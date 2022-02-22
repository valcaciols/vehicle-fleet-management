using MediatR;
using VehicleFleetManagement.Application.DomainEvents.Clients;
using VehicleFleetManagement.Domain.Denormalizeds;
using VehicleFleetManagement.Domain.Denormalizeds.Repositories;

namespace VehicleFleetManagement.Application.DomainEventHandlers.Clients
{
    public class CreateVehicleDomainEventHandler : INotificationHandler<CreateVehicleDomainEvent>
    {
        private readonly IDenormalizedVehicleRepository _denormalizedVehicle;

        public CreateVehicleDomainEventHandler(IDenormalizedVehicleRepository denormalizedVehicle)
        {
            _denormalizedVehicle = denormalizedVehicle;
        }

        public async Task Handle(CreateVehicleDomainEvent notification, CancellationToken cancellationToken)
        {

            var vehicle = new DenormalizedVehicle
            {
                VehicleId = notification.VehicleId,
                LicensePlate = notification.LicensePlate,
                ModelManufacturer = notification.ModelManufacturer,
                ModelName = notification.ModelName,
                StatusId = notification.StatusId,
                StatusName = notification.StatusName,
            };

            await _denormalizedVehicle.AddAsync(vehicle);

        }
    }
}
