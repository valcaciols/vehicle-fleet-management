using MediatR;
using VehicleFleetManagement.Application.ViewModels.Responses;

namespace VehicleFleetManagement.Application.Commands.Booking
{
    public class UpdateBookingExpectedDateCommand : IRequest<CommandResponse<UpdateBookingExpectedDateResponse>>
    {
        public int BookingId { get; set; }
        public DateTime? DateExpectedWithdrawn { get; set; }
        public DateTime? DateExpectedReturn { get; set; }
    }
}
