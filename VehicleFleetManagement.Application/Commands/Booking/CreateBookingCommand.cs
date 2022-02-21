using MediatR;
using VehicleFleetManagement.Application.ViewModels.Responses;

namespace VehicleFleetManagement.Application.Commands.Booking
{
    public class CreateBookingCommand : IRequest<CommandResponse<CreateBookingResponse>>
    {
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public DateTime DateWithdrawn { get; set; }
        public DateTime DateExpectedReturn { get; set; }
    }
}
