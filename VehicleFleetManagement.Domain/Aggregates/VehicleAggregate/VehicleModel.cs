using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.VehicleAggregate
{
    public class VehicleModel: Entity
    {
        public string Name { get; set; }
        public int VehicleManufacturerId { get; private set; }
        public string VehicleManufacturerName { get; private set; }

        public VehicleManufacturer Manufacturer { get => new VehicleManufacturer { Id = VehicleManufacturerId, Name = VehicleManufacturerName };}
        
        public VehicleModel()
        {

        }

        public VehicleModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
