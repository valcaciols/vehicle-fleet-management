using MediatR;

namespace VehicleFleetManagement.Application.DomainEvents.Clients
{
    public class CreateBookingDomainEvent : INotification
    {
        public int BookingId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int VehicleId { get; set; }
        public string VehicleModel { get; set; }
        public string LicensePlate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateWithdrawn { get; set; }
        public DateTime DateExpectedReturn { get; set; }
    }
}
