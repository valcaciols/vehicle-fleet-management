using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleFleetManagement.Application.Commands.Booking;
using VehicleFleetManagement.Application.Queries;
using VehicleFleetManagement.Application.ViewModels.Booking;
using VehicleFleetManagement.Application.ViewModels.Responses;

namespace VehicleFleetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBookingQueries _bookingQueries;

        public BookingController(IMediator mediator, IBookingQueries bookingQueries)
        {
            _mediator = mediator;
            _bookingQueries = bookingQueries;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BookingViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] BookingRequest request)
        {
            var result = await _bookingQueries.GetAllAsync(request.ClientId, request.Cpf, request.Name);
            return Ok(result);
        }

        [HttpGet("withdrawn")]
        [ProducesResponseType(typeof(BookingViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllWithdrawn([FromQuery] DateTime? inicialDate, [FromQuery] DateTime? endDate)
        {
            var result = await _bookingQueries.GetAllWithdrawnAsync(inicialDate, endDate);
            return Ok(result);
        }

        [HttpPut("withdrawn/expected/{bookingId}")]
        [ProducesResponseType(typeof(CloseBookingResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutExpectedDate(int bookingId, [FromBody] UpdateBookingExpectedDateCommand command)
        {
            if (bookingId != command.BookingId)
                return BadRequest();

            var response = await _mediator.Send(command);

            if (!response.Status)
            {
                return BadRequest(response);
            }

            return Ok(response.Data);
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


        [HttpPut("close/{bookingId}")]
        [ProducesResponseType(typeof(CloseBookingResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Return(int? bookingId)
        {
            if (bookingId == null)
                return BadRequest();

            var command = new CloseBookingCommand { BookingId = bookingId.Value };
            
            var response = await _mediator.Send(command);

            if (!response.Status)
            {
                return BadRequest(response);
            }

            return Ok(response.Data);
        }
    }
}
