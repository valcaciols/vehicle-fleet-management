namespace VehicleFleetManagement.Application.ViewModels.Responses
{
    public class CreateBookingResponse
    {
        public int BookingId { get; set; }
        public string ClientName{ get; private set; }
        public string? VehicleModel { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateExpectedWithdrawn { get; private set; }
        public DateTime DateExpectedReturn { get; private set; }

        public CreateBookingResponse(
            int bookingId,
            string clientName,
            string vehicleModel,
            DateTime dateCreated,
            DateTime? dateExpectedWithdrawn,
            DateTime dateExpectedReturn)
        {
            BookingId = bookingId;
            ClientName = clientName;
            VehicleModel = vehicleModel;
            DateCreated = dateCreated;
            DateExpectedWithdrawn = dateExpectedWithdrawn;
            DateExpectedReturn = dateExpectedReturn;
        }
    }
}
