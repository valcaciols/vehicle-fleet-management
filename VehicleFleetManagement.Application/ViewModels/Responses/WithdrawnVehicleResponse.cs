namespace VehicleFleetManagement.Application.ViewModels.Responses
{
    public class WithdrawnVehicleResponse
    {
        public int BookingId { get; set; }
        public int VehicleId { get; set; }
        public DateTime? DateWithdrawn { get; set; }
        public DateTime? DateReturn { get; set; }
    }
}
