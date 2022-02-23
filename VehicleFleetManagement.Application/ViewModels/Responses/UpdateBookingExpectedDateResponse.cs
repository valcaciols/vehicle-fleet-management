namespace VehicleFleetManagement.Application.ViewModels.Responses
{
    public class UpdateBookingExpectedDateResponse
    {
        public int BookingId{ get; set; }
        public DateTime? DateExpectedWithdrawn { get; set; }
        public DateTime? DateExpectedReturn { get; set; }
    }
}
