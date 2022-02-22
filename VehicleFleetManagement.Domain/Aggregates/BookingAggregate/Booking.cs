using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.BookingAggregate
{
    public class Booking: Entity, IAggregateRoot
    {
        public int ClientId { get; set; }
        public int VehicleId { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateWithdrawn { get; private set; }
        public DateTime? DateExpectedWithdrawn { get; private set; }

        public DateTime DateExpectedReturn { get; private set; }
        public DateTime? DateReturn { get; private set; }

        public Booking()
        {

        }

        public Booking(
            int clientId, 
            int vehicleId, 
            DateTime dateExpectedWithdrawn, 
            DateTime dateExpectedReturn)
        {
            ClientId = clientId;
            VehicleId = vehicleId;
            DateCreated = DateTime.Now;
            DateExpectedWithdrawn = dateExpectedWithdrawn;
            DateExpectedReturn = dateExpectedReturn;
        }

        public bool IsOpen()
        {
            return !DateReturn.HasValue;
        }

    }
}
