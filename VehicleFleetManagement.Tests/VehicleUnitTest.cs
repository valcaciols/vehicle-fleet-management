using MediatR;
using Moq;
using System.Threading.Tasks;
using VehicleFleetManagement.Application.CommandHandlers.Vehicles;
using VehicleFleetManagement.Application.Commands.Vehicle;
using VehicleFleetManagement.Tests.Mocks.Booking;
using VehicleFleetManagement.Tests.Mocks.Vehicle;
using Xunit;

namespace VehicleFleetManagement.Tests
{
    public class VehicleUnitTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly MockVehicleRepository _vehicleRepository;
        private readonly MockVehicleModelRepository _vehicleModelRepository;
        private readonly MockBookingRepository _bookingRepository;

        public VehicleUnitTest()
        {
            _mediator = new Mock<IMediator>();
            _vehicleRepository = new MockVehicleRepository();
            _vehicleModelRepository = new MockVehicleModelRepository();
            _bookingRepository = new MockBookingRepository();
        }

        [Fact]
        public async Task TestCreateVehicleAsync()
        {
            var command = new CreateVehicleCommand("J3R5864", 0);
            var vehicleHandler = new CreateVehicleCommandHandler(_vehicleRepository, _vehicleModelRepository, _mediator.Object);
            var response = await vehicleHandler.Handle(command, new System.Threading.CancellationToken());

            Assert.True(response.Status);
        }

        [Fact]
        public async Task TestWithdrawnVehicleAsync()
        {
            var command = new WithdrawnVehicleCommand { BookingId = 0, VehicleId = 1};
            var vehicleHandler = new WithdrawnVehicleCommandHandler(_vehicleRepository, _bookingRepository, _mediator.Object);
            var response = await vehicleHandler.Handle(command, new System.Threading.CancellationToken());

            Assert.True(response.Status);
        }

        [Fact]
        public async Task GetVehiclesAsync()
        {
            var queries = new MockVehicleQueries();
            var response = await queries.GetAllAsync(null, null, null);

            Assert.True(response != null && response.Count > 0);
        }
    }
}