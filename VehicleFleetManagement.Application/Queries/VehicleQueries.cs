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

        public async Task<List<VehicleViewModel>> GetAllAsync(string? licensePlate, string? model, string? manufacturer)
        {
            var query = @$"SELECT * FROM [dbo].[DenormalizedVehicle]";

            if (!string.IsNullOrEmpty(licensePlate))
                query += AddParameters(query, $"[LicensePlate] LIKE '%{licensePlate}%'");

            if (!string.IsNullOrEmpty(model))
                query += AddParameters(query, $"[ModelName] LIKE '%{model}%'");

            if (!string.IsNullOrEmpty(manufacturer))
                query += AddParameters(query, $"[ModelManufacturer] LIKE '%{manufacturer}%'");

            var result = await _context.connection.QueryAsync<VehicleViewModel>(query);

            return result.ToList();
        }


    }
}
