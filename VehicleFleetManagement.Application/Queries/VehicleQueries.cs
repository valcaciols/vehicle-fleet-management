using Dapper;
using VehicleFleetManagement.Application.ViewModels.Vehicle;
using VehicleFleetManagement.Infrastructure.Repositories;

namespace VehicleFleetManagement.Application.Queries
{
    public class VehicleQueries : QueriesBase, IVehicleQueries
    {
        public VehicleQueries(VehicleManagerContext context) : base(context)
        {
        }

        public async Task<List<VehicleViewModel>> GetAllAsync(string licensePlate)
        {
            var query = @$"SELECT * FROM [dbo].[DenormalizedVehicle]";

            if (!string.IsNullOrEmpty(licensePlate))
                query += $" WHERE [LicensePlate] LIKE '{licensePlate}'";

            var result = await _context.connection.QueryAsync<VehicleViewModel>(query);

            return result.ToList();
        }
    }
}
