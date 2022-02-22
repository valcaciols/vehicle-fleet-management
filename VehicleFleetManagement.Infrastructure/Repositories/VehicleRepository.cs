using VehicleFleetManagement.Domain.Aggregates.VehicleAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(VehicleManagerContext context) : base(context)
        {
        }

        public async Task<Vehicle> AddAsync(Vehicle vehicle)
        {
            var query = $@"INSERT INTO [dbo].[Vehicle]
                               ([LicensePlate]
                               ,[Status]
                               ,[VehicleModelId])
                         VALUES
                               ('{vehicle.LicensePlate}'
                               ,{(int)vehicle.Status}
                               ,{vehicle.VehicleModelId})";

            vehicle.Id = await AddQueryAsync(query);
            return vehicle;
        }

        public async Task<bool> ExistAsync(string licencePlate)
        {
            var query = $@"SELECT * FROM [dbo].[Vehicle] WHERE [LicensePlate]={licencePlate}";
            var result = await GetQueryAsync(query);
            return result != null;
        }

        public async Task<Vehicle?> GetAsync(int id)
        {
            var query = $@"SELECT * FROM [dbo].[Vehicle] WHERE [Id]={id}";
            return await GetQueryAsync(query);
        }

        public async Task UpdateStatusAsync(int id, VehicleStatus status)
        {
            var vehicle = await GetAsync(id);

            if (vehicle == null)
                return;

            vehicle.ChangeStatus(status);

            var query = $@"UPDATE [dbo].[Vehicle]
                           SET [Status] = {(int)vehicle.Status}
                         WHERE [Id]={id}";

            await UpdateQueryAsync(query);
        }
    }
}
