using MediatR;
using VehicleFleetManagement.Application.Commands.Vehicle;
using VehicleFleetManagement.Application.DomainEvents.Booking;
using VehicleFleetManagement.Application.DomainEvents.Clients;
using VehicleFleetManagement.Application.ViewModels.Responses;
using VehicleFleetManagement.Domain.Aggregates.BookingAggregate;
using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Application.CommandHandlers.Vehicles
{
    public class WithdrawnVehicleCommandHandler : CommandHandler<WithdrawnVehicleResponse>, IRequestHandler<WithdrawnVehicleCommand, CommandResponse<WithdrawnVehicleResponse>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMediator _mediator;

        public WithdrawnVehicleCommandHandler(IVehicleRepository vehicleRepository, IBookingRepository bookingRepository, IMediator mediator)
        {
            _vehicleRepository = vehicleRepository;
            _bookingRepository = bookingRepository;
            _mediator = mediator;
        }

        public async Task<CommandResponse<WithdrawnVehicleResponse>> Handle(WithdrawnVehicleCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetAsync(request.BookingId);

            if (booking == null)
                return await Fail("Reserva não encontrada");

            if (booking.DateReturn != null)
                return await Fail("Reserva encerrada");

            var vehicle = await _vehicleRepository.GetAsync(request.VehicleId);

            if (vehicle == null)
                return await Fail("Veiculo não encontrado");

            if (vehicle.Id != booking.VehicleId)
                return await Fail("Esse carro não pertence a essa reserva");

            if (booking.DateWithdrawn != null)
                return await Fail("Veiculo já foi retirado");

            await _vehicleRepository.UpdateStatusAsync(vehicle.Id, (int) VehicleStatus.Busy);

            await _mediator.Publish(new UpdateStatusVehicleDomainEvent
            {
                VehicleId = vehicle.Id,
                StatusId = (int) VehicleStatus.Busy,
                StatusName = VehicleStatus.Busy.ToString(),

            });

            var dateWithdrawn = DateTime.Now;

            await _mediator.Publish(new UpdateBookingWithdrawnDomainEvent
            {
                VehicleId = vehicle.Id,
                BookingId = booking.Id,
                DateWithdrawn = dateWithdrawn
            });

            var vehicleResponse = new WithdrawnVehicleResponse 
            { 
                BookingId = booking.Id,
                DateWithdrawn = dateWithdrawn,
                DateReturn = booking.DateReturn,
                VehicleId = vehicle.Id
            };

            return await Ok(vehicleResponse);
        }
    }
}
