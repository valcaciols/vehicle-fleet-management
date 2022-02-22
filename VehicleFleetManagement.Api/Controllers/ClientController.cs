using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using VehicleFleetManagement.Application.ViewModels.Client;
using VehicleFleetManagement.Application.ViewModels.Requests;
using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;
using VehicleFleetManagement.Application.Commands;
using VehicleFleetManagement.Application.CommandHandlers.Clients;
using VehicleFleetManagement.Application.ViewModels.Responses;
using MediatR;
using VehicleFleetManagement.Domain.Denormalizeds.Repositories;
using VehicleFleetManagement.Domain.Denormalizeds;

namespace VehicleFleetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IClientRepository _clientRepository;

        public ClientController(IMediator mediator, IClientRepository clientRepository)
        {
            _mediator = mediator;
            _clientRepository = clientRepository;
        }

        [HttpGet("{clientId}")]
        [ProducesResponseType(typeof(DenormalizedClient), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int clientId)
        {
            var client = await _clientRepository.GetAsync(clientId);
            return Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClientResponse),StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] CreateClientCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.Status)
            {
                return BadRequest(response);
            }

            return Ok(response.Data);
        }
    }
}
