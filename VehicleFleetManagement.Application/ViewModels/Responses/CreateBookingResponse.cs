namespace VehicleFleetManagement.Application.ViewModels.Responses
{
    public class CreateBookingResponse
    {
        public string ClientName{ get; private set; }
        public string? VehicleModel { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateWithdrawn { get; private set; }
        public DateTime DateExpectedReturn { get; private set; }

        public CreateBookingResponse(
            string clientName,
            string vehicleModel,
            DateTime dateCreated,
            DateTime dateWithdrawn,
            DateTime dateExpectedReturn)
        {
            ClientName = clientName;
            VehicleModel = vehicleModel;
            DateCreated = dateCreated;
            DateWithdrawn = dateWithdrawn;
            DateExpectedReturn = dateExpectedReturn;
        }
    }
}
