using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.BookingAggregate
{
    public class Booking: Entity, IAggregateRoot
    {
        public int ClientId { get; set; }
        public int VehicleId { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateWithdrawn { get; private set; }
        public DateTime DateExpectedReturn { get; private set; }
        public DateTime? DateReturn { get; private set; }

        public Booking()
        {

        }

        public Booking(
            int clientId, 
            int vehicleId, 
            DateTime dateWithdrawn, 
            DateTime dateExpectedReturn)
        {
            ClientId = clientId;
            VehicleId = vehicleId;
            DateCreated = DateTime.Now;
            DateWithdrawn = dateWithdrawn;
            DateExpectedReturn = dateExpectedReturn;
        }

        public bool IsOpen()
        {
            return !DateReturn.HasValue;
        }

    }
}
