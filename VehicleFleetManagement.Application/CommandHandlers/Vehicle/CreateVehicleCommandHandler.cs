using MediatR;
using VehicleFleetManagement.Application.Commands.Vehicle;
using VehicleFleetManagement.Application.ViewModels.Responses;
using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Application.CommandHandlers.Vehicles
{
    public class CreateVehicleCommandHandler : CommandHandler<CreateVehicleResponse>, IRequestHandler<CreateVehicleCommand, CommandResponse<CreateVehicleResponse>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;

        public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository, IVehicleModelRepository vehicleModelRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleModelRepository = vehicleModelRepository;
        }

        public async Task<CommandResponse<CreateVehicleResponse>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var hasVehicle = await _vehicleRepository.ExistAsync(request.LicensePlate);

            if (hasVehicle)
                return await Fail("Já existe um veiculo com essa placa cadastrada");

            var vehicleModel = await _vehicleModelRepository.GetAsync(request.VehicleModelId);

            if (vehicleModel == null)
                return await Fail("Não existe este modelo em nossa base");

            var vehicle = new Vehicle(request.LicensePlate, request.VehicleModelId);
            
            var vehicleResult = await _vehicleRepository.AddAsync(vehicle);

            var vehicleResponse = new CreateVehicleResponse(vehicleResult.LicensePlate, vehicleModel.Name, vehicleModel.Manufacturer.Name);

            return await Ok(vehicleResponse);
        }
    }
}
