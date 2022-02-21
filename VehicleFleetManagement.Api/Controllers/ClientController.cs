using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using VehicleFleetManagement.Application.ViewModels.Client;
using VehicleFleetManagement.Application.ViewModels.Requests;
using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;
using VehicleFleetManagement.Application.Commands;
using VehicleFleetManagement.Application.CommandHandlers.Clients;
using VehicleFleetManagement.Application.ViewModels.Responses;
using MediatR;

namespace VehicleFleetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(List<ClientViewModel>), StatusCodes.Status200OK)]
        //public IActionResult GetAll([FromQuery] ClientRequest clientRequest)
        //{
        //    return Ok();
        //}

        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(ClientViewModel), StatusCodes.Status200OK)]
        //public IActionResult Get(int id)
        //{
        //    return Ok();
        //}

        [HttpPost]
        [ProducesResponseType(typeof(ClientResponse),StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] CreateClientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
