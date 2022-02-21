using MediatR;
using VehicleFleetManagement.Application.Commands;
using VehicleFleetManagement.Application.ViewModels.Responses;
using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;

namespace VehicleFleetManagement.Application.CommandHandlers.Clients
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ClientResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository, IAddressRepository addressRepository)
        {
            _clientRepository = clientRepository;
            _addressRepository = addressRepository;
        }

        public async Task<ClientResponse> Handle(CreateClientCommand command, CancellationToken cancellationToken)
        {
            var isClient = await _clientRepository.ExistAsync(command.Cpf, command.Cnh);

            if (isClient)
                throw new InvalidOperationException("Usuário já existente na base");

            var client = new Client(command.Name, command.Cpf, command.BirthDate, command.Cnh); 

            var clientResult = await _clientRepository.AddAsync(client);

            var address = new Address(clientResult.Id, command.Street, command.City, command.Cep);

            await _addressRepository.AddAsync(address);

            return new ClientResponse(
                    clientResult.Name, 
                    clientResult.Cpf, 
                    clientResult.Cnh, 
                    clientResult.BirthDate);
        }
    }
}
