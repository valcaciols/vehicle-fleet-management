using MediatR;
using VehicleFleetManagement.Application.Commands.Booking;
using VehicleFleetManagement.Application.DomainEvents.Booking;
using VehicleFleetManagement.Application.DomainEvents.Clients;
using VehicleFleetManagement.Application.ViewModels.Responses;
using VehicleFleetManagement.Domain.Aggregates.BookingAggregate;
using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;
using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Application.CommandHandlers.Bookings
{
    public class UpdateBookingExpectedDateCommandHandler : CommandHandler<UpdateBookingExpectedDateResponse>, IRequestHandler<UpdateBookingExpectedDateCommand, CommandResponse<UpdateBookingExpectedDateResponse>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IMediator _mediator;

        public UpdateBookingExpectedDateCommandHandler(
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

        public async Task<CommandResponse<UpdateBookingExpectedDateResponse>> Handle(UpdateBookingExpectedDateCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetAsync(request.BookingId);

            if (booking == null)
                return await Fail("Reserva não encontrada");

            if (!booking.IsOpen())
                return await Fail("Reserva já está fechada");

            await _bookingRepository.UpdateExpectedDateAsync(booking.Id, request.DateExpectedWithdrawn, request.DateExpectedReturn);

            await _mediator.Publish(new UpdateBookingExpectedDateDomainEvent
            { 
                BookingId = booking.Id,
                DateExpectedWithdrawn = request.DateExpectedWithdrawn,
                DateExpectedReturn = request.DateExpectedReturn
            });

            return await Ok(new UpdateBookingExpectedDateResponse 
            {
                BookingId = booking.Id,
                DateExpectedWithdrawn = request.DateExpectedWithdrawn,
                DateExpectedReturn = request.DateExpectedReturn
            });
        }
    }
}
