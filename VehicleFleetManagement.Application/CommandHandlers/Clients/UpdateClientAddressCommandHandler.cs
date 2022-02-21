using MediatR;
using VehicleFleetManagement.Application.Commands.Client;
using VehicleFleetManagement.Application.ViewModels.Responses;
using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;

namespace VehicleFleetManagement.Application.CommandHandlers.Clients
{
    public class UpdateClientAddressCommandHandler : CommandHandler<UpdateClientAddressResponse>, IRequestHandler<UpdateClientAddressCommand, CommandResponse<UpdateClientAddressResponse>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRepository;

        public UpdateClientAddressCommandHandler(IClientRepository clientRepository, IAddressRepository addressRepository)
        {
            _clientRepository = clientRepository;
            _addressRepository = addressRepository;
        }

        public async Task<CommandResponse<UpdateClientAddressResponse>> Handle(UpdateClientAddressCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetAsync(request.ClientId);

            if (client == null)
                return await Fail("Cliente não encontrado");

            var address = await _addressRepository.GetByClientIdAsync(request.ClientId);

            if (address == null)
            {
                if (!IsValidRequest(request))
                    return await Fail("Endereço não encontrado! Preencha os dados obrigatórios");

                address = new Address(client.Id, request.Street, request.City, request.Cep);

                var AddAddressResult = await _addressRepository.AddAsync(address);

                var AddaddressResponse = new UpdateClientAddressResponse(
                        client.Name,
                        AddAddressResult.Street,
                        AddAddressResult.City,
                        AddAddressResult.Cep);
                
                return await Ok(AddaddressResponse);
            }

            address.Change(request.Street, request.City, request.Cep);

            var addressResult = await _addressRepository.UpdateAddressAsync(address);

            var addressResponse = new UpdateClientAddressResponse(
                    client.Name,
                    addressResult.Street,
                    addressResult.City,
                    addressResult.Cep);

            return await Ok(addressResponse);
        }

        private bool IsValidRequest(UpdateClientAddressCommand request)
        {
            if(request.Street == null || request.City == null || request.Cep == 0)
                return false;

            return true;
        }
    }
}
