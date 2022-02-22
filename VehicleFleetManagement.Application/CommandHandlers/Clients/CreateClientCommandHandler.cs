using MediatR;
using VehicleFleetManagement.Application.Commands;
using VehicleFleetManagement.Application.DomainEvents.Clients;
using VehicleFleetManagement.Application.ViewModels.Responses;
using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;

namespace VehicleFleetManagement.Application.CommandHandlers.Clients
{
    public class CreateClientCommandHandler : CommandHandler<ClientResponse>, IRequestHandler<CreateClientCommand, CommandResponse<ClientResponse>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMediator _mediator;

        public CreateClientCommandHandler(IClientRepository clientRepository, IAddressRepository addressRepository, IMediator mediator)
        {
            _clientRepository = clientRepository;
            _addressRepository = addressRepository;
            _mediator = mediator;
        }

        public async Task<CommandResponse<ClientResponse>> Handle(CreateClientCommand command, CancellationToken cancellationToken)
        {
            var isClient = await _clientRepository.ExistAsync(command.Cpf, command.Cnh);

            if (isClient)
                return await Fail("Usuário já existente na base");

            var client = new Client(0, command.Name, command.Cpf, command.BirthDate, command.Cnh); 

            var clientResult = await _clientRepository.AddAsync(client);

            var address = new Address(clientResult.Id, command.Street, command.City, command.Cep);

            await _addressRepository.AddAsync(address);

            await _mediator.Publish(new CreateClientDomainEvent
            {
                ClientId = clientResult.Id,
                Name = clientResult.Name,
                Cpf = clientResult.Cpf,
                Cnh = clientResult.Cnh,
                BirthDate = clientResult.BirthDate,
                Street = address.Street,
                City = address.City,
                Cep = address.Cep
            });

            return await Ok( new ClientResponse(
                    clientResult.Name,
                    clientResult.Cpf,
                    clientResult.Cnh,
                    clientResult.BirthDate));
        }
    }
}
