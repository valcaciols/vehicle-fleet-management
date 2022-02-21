using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleFleetManagement.Application.Commands.Vehicle;
using VehicleFleetManagement.Application.ViewModels.Responses;

namespace VehicleFleetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateVehicleResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] CreateVehicleCommand command)
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
