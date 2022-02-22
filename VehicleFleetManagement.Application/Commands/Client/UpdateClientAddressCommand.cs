using MediatR;
using VehicleFleetManagement.Application.ViewModels.Responses;

namespace VehicleFleetManagement.Application.Commands.Client
{
    public class UpdateClientAddressCommand: Command, IRequest<CommandResponse<UpdateClientAddressResponse>>
    {
        public int ClientId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Cep { get; set; }

    }
}
