using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleFleetManagement.Application.Commands.Vehicle;
using VehicleFleetManagement.Application.Queries;
using VehicleFleetManagement.Application.ViewModels.Responses;
using VehicleFleetManagement.Application.ViewModels.Vehicle;

namespace VehicleFleetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IVehicleQueries _vehicleQueries;

        public VehicleController(IMediator mediator, IVehicleQueries vehicleQueries)
        {
            _mediator = mediator;
            _vehicleQueries = vehicleQueries;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<VehicleViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] VehicleRequest request)
        {
            var result =  await _vehicleQueries.GetAllAsync(request.LicensePlate, request.Model, request.Manufacturer);
            return Ok(result);
        }

        [HttpPut("withdrawn")]
        [ProducesResponseType(typeof(WithdrawnVehicleResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] WithdrawnVehicleCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.Status)
            {
                return BadRequest(response);
            }

            return Ok(response.Data);
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
