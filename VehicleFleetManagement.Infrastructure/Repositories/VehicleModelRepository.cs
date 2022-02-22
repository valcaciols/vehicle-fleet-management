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
            var query = $@"SELECT * FROM [dbo].[VehicleModel] WHERE [Id]={id}";
            return await GetQueryAsync(query);
        }
    }
}
