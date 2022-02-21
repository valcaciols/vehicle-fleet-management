namespace VehicleFleetManagement.Application.ViewModels.Responses
{
    public class CreateVehicleResponse
    {
        public string LicensePlate { get; private set; }
        public string ModelName { get; private set; }
        public string ModelManufacturer { get; private set; }

        public CreateVehicleResponse(string licensePlate, string modelName, string modelManufacturer)
        {
            LicensePlate = licensePlate;
            ModelName = modelName;
            ModelManufacturer = modelManufacturer;
        }
    }
}
