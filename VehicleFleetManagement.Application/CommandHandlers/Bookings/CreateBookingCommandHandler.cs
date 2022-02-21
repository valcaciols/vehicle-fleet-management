using MediatR;
using VehicleFleetManagement.Application.Commands.Booking;
using VehicleFleetManagement.Application.ViewModels.Responses;
using VehicleFleetManagement.Domain.Aggregates.BookingAggregate;
using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;
using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Application.CommandHandlers.Bookings
{
    public class CreateBookingCommandHandler : CommandHandler<CreateBookingResponse>, IRequestHandler<CreateBookingCommand, CommandResponse<CreateBookingResponse>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public CreateBookingCommandHandler(
                IBookingRepository bookingRepository,
                IClientRepository clientRepository,
                IVehicleRepository vehicleRepository)
        {
            _bookingRepository = bookingRepository;
            _clientRepository = clientRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<CommandResponse<CreateBookingResponse>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetAsync(request.ClientId);

            if (client == null)
                return await Fail("Cliente não encontrado");

            var vehicle = await _vehicleRepository.GetAsync(request.VehicleId);

            if (vehicle == null)
                return await Fail("Cliente não encontrado");

            var clienteHasBooking = await _bookingRepository.ExistActiveByClientId(request.ClientId);

            if (clienteHasBooking)
                return await Fail("Cliente já possui reserva ativa");

            if (!IsDateValidBooking(request))
                return await Fail("Data de reserva inválida");

            var booking = new Booking(client, vehicle, request.DateWithdrawn, request.DateExpectedReturn);

            var bookingResult = await _bookingRepository.AddAsync(booking);

            var bookingResponse =  new CreateBookingResponse(
                client.Name,
                GetVehicleName(vehicle), 
                bookingResult.DateCreated, 
                booking.DateWithdrawn, 
                bookingResult.DateExpectedReturn);

            return await Ok(bookingResponse);
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
