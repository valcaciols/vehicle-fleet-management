using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;
using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;
using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.BookingAggregate
{
    public class Booking: Entity, IAggregateRoot
    {
        public int ClientId { get; set; }
        public Client Client { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateWithdrawn { get; private set; }
        public DateTime DateExpectedReturn { get; private set; }
        public DateTime? DateReturn { get; private set; }

        public Booking(
            Client client, 
            Vehicle vehicle, 
            DateTime dateWithdrawn, 
            DateTime dateExpectedReturn)
        {
            ClientId = client.Id;
            Client = client;
            Vehicle = vehicle;
            DateCreated = DateTime.Now;
            DateWithdrawn = dateWithdrawn;
            DateExpectedReturn = dateExpectedReturn;
        }

    }
}
