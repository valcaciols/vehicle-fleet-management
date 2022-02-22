using MediatR;
using VehicleFleetManagement.Application.DomainEvents.Clients;
using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;
using VehicleFleetManagement.Domain.Denormalizeds.Repositories;

namespace VehicleFleetManagement.Application.DomainEventHandlers.Clients
{
    public class UpdateStatusVehicleDomainEventHandler : INotificationHandler<UpdateStatusVehicleDomainEvent>
    {
        private readonly IDenormalizedVehicleRepository _denormalizedVehicle;
        private readonly IVehicleRepository _vehicleRepository;

        public UpdateStatusVehicleDomainEventHandler(IDenormalizedVehicleRepository denormalizedVehicle, IVehicleRepository vehicleRepository)
        {
            _denormalizedVehicle = denormalizedVehicle;
            _vehicleRepository = vehicleRepository;
        }

        public async Task Handle(UpdateStatusVehicleDomainEvent notification, CancellationToken cancellationToken)
        {
            await _vehicleRepository.UpdateStatusAsync(notification.VehicleId, notification.StatusId);
            await _denormalizedVehicle.UpdateStatusAsync(notification.VehicleId, notification.StatusId, notification.StatusName);
        }
    }
}
