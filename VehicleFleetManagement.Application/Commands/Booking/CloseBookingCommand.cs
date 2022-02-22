using MediatR;
using VehicleFleetManagement.Application.ViewModels.Responses;

namespace VehicleFleetManagement.Application.Commands.Booking
{
    public class CloseBookingCommand: IRequest<CommandResponse<CloseBookingResponse>>
    {
        public int BookingId { get; set; }
    }
}
