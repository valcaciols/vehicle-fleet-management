using MediatR;
using VehicleFleetManagement.Application.Commands.Booking;
using VehicleFleetManagement.Application.DomainEvents.Clients;
using VehicleFleetManagement.Application.ViewModels.Responses;
using VehicleFleetManagement.Domain.Aggregates.BookingAggregate;
using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;
using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Application.CommandHandlers.Bookings
{
    public class CloseBookingCommandHandler : CommandHandler<CloseBookingResponse>, IRequestHandler<CloseBookingCommand, CommandResponse<CloseBookingResponse>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IMediator _mediator;

        public CloseBookingCommandHandler(
                IBookingRepository bookingRepository,
                IClientRepository clientRepository,
                IVehicleRepository vehicleRepository,
                IVehicleModelRepository vehicleModelRepository,
                IMediator mediator)
        {
            _bookingRepository = bookingRepository;
            _clientRepository = clientRepository;
            _vehicleRepository = vehicleRepository;
            _vehicleModelRepository = vehicleModelRepository;
            _mediator = mediator;
        }

        public async Task<CommandResponse<CloseBookingResponse>> Handle(CloseBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetAsync(request.BookingId);

            if (booking == null)
                return await Fail("Reserva não encontrada");

            if (!booking.IsOpen())
                return await Fail("Reserva já está fechada");

            var dateReturn = DateTime.Now;

            await _bookingRepository.UpdateDateReturnAsync(booking.Id, dateReturn);

            await _mediator.Publish(new CloseBookingDomainEvent
            { 
                BookingId = booking.Id,
                DateReturn = dateReturn
            });

            await _mediator.Publish(new UpdateStatusVehicleDomainEvent
            {
                VehicleId = booking.VehicleId,
                StatusId = (int) VehicleStatus.Available,
                StatusName = VehicleStatus.Available.ToString(),
            });

            return await Ok(new CloseBookingResponse(booking.Id, dateReturn));
        }

        private bool IsDateValidBooking(CreateBookingCommand request)
        {
            if (request.DateExpectedReturn.DayOfYear <= request.DateWithdrawn.DayOfYear)
                return false;

            return true;
        }

        private string GetVehicleName(Vehicle vehicle)
        {
            return vehicle.VehicleModel != null ? vehicle.VehicleModel.Name : "";
        }
    }
}
