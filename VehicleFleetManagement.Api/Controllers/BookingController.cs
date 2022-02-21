using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleFleetManagement.Application.Commands.Booking;
using VehicleFleetManagement.Application.ViewModels.Responses;

namespace VehicleFleetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateBookingResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] CreateBookingCommand command)
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
