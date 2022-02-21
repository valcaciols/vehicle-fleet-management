using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.VehicleAggregate
{
    public class VehicleManufacturer: Entity
    {
        public string Name { get; private set; }

        public VehicleManufacturer(string name)
        {
            Name = name;
        }
    }
}
