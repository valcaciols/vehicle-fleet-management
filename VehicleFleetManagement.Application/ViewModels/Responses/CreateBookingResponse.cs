namespace VehicleFleetManagement.Application.ViewModels.Responses
{
    public class CreateBookingResponse
    {
        public string ClientName{ get; private set; }
        public string? VehicleModel { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateExpectedWithdrawn { get; private set; }
        public DateTime DateExpectedReturn { get; private set; }

        public CreateBookingResponse(
            string clientName,
            string vehicleModel,
            DateTime dateCreated,
            DateTime? dateExpectedWithdrawn,
            DateTime dateExpectedReturn)
        {
            ClientName = clientName;
            VehicleModel = vehicleModel;
            DateCreated = dateCreated;
            DateExpectedWithdrawn = dateExpectedWithdrawn;
            DateExpectedReturn = dateExpectedReturn;
        }
    }
}
