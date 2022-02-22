using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class VehicleModelRepository : Repository<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepository(VehicleManagerContext context) : base(context)
        {
        }

        public async Task<VehicleModel?> GetAsync(int id)
        {
            var query = $@"SELECT vm.Id, vm.Name, vm.VehicleManufacturerId, vh.Name VehicleManufacturerName FROM [dbo].[VehicleModel] vm
                            INNER JOIN [dbo].[VehicleManufacturer]vh ON vm.VehicleManufacturerId = vh.Id WHERE vm.Id={id}";
            return await GetQueryAsync(query);
        }
    }
}
