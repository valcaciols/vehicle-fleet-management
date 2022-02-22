using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Denormalizeds
{
    public class DenormalizedVehicle : Entity
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public string ModelName { get; set; }
        public string ModelManufacturer { get; set; }
    }
}
