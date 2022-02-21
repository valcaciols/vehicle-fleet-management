using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleFleetManagement.Application.Commands.Client;
using VehicleFleetManagement.Application.ViewModels.Responses;

namespace VehicleFleetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UpdateClientAddressResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateClientAddress(UpdateClientAddressCommand command)
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
