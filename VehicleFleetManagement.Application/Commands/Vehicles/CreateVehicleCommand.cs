using MediatR;
using VehicleFleetManagement.Application.ViewModels.Responses;

namespace VehicleFleetManagement.Application.Commands.Vehicle
{
    public class CreateVehicleCommand : Command, IRequest<CommandResponse<CreateVehicleResponse>>
    {
        public string LicensePlate { get; private set; }
        public int VehicleModelId { get; private set; }

        public CreateVehicleCommand(string licensePlate, int vehicleModelId)
        {
            LicensePlate = licensePlate;
            VehicleModelId = vehicleModelId;
        }
    }
}
