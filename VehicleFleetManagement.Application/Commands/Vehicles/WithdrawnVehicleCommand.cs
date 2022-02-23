using MediatR;
using VehicleFleetManagement.Application.ViewModels.Responses;

namespace VehicleFleetManagement.Application.Commands.Vehicle
{
    public class WithdrawnVehicleCommand : Command, IRequest<CommandResponse<WithdrawnVehicleResponse>>
    {
        public int BookingId { get; set; }
        public int VehicleId { get; set; }
    }
}
