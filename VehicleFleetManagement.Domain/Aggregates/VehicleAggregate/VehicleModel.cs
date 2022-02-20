using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.VehicleAggregate
{
    public class VehicleModel: Entity
    {
        public string Name { get; set; }
        public int VehicleManufacturerId { get; private set; }
        public VehicleManufacturer Manufacturer { get; private set; }

        public VehicleModel(string name, VehicleManufacturer manufacturer)
        {
            Name = name;
            Manufacturer = manufacturer;
            VehicleManufacturerId = manufacturer.Id;
        }
    }
}
