using MediatR;
using VehicleFleetManagement.Application.ViewModels.Responses;

namespace VehicleFleetManagement.Application.Commands
{
    public class CreateClientCommand: Command, IRequest<CommandResponse<ClientResponse>>
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cnh { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Cep { get; set; }
    }
}
