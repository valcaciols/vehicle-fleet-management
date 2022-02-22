﻿using Dapper;
using VehicleFleetManagement.Domain.Denormalizeds;
using VehicleFleetManagement.Domain.Denormalizeds.Repositories;
using VehicleFleetManagement.Infrastructure.Repositories;

namespace VehicleFleetManagement.Infrastructure.Denormalizeds
{
    public class DenormalizedVehicleRepository : IDenormalizedVehicleRepository
    {
        private readonly VehicleManagerContext _context;

        public DenormalizedVehicleRepository(VehicleManagerContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DenormalizedVehicle entity)
        {
            var query = $@"INSERT INTO [dbo].[DenormalizedVehicle]
                       ([VehicleId]
                       ,[LicensePlate]
                       ,[ModelName]
                       ,[ModelManufacturer])
                     VALUES
                           ({entity.VehicleId}
                           ,'{entity.LicensePlate}'
                           ,'{entity.ModelName}'
                           ,'{entity.ModelManufacturer}')";

            query += "SELECT CAST(SCOPE_IDENTITY() as int)";

            await _context.connection.QuerySingleAsync<int>(query);
        }

        public async Task<DenormalizedVehicle> GetAsync(int id)
        {
            var query = $"SELECT * FROM [DenormalizedVehicle].[dbo].[DenormalizedClient] WHERE [VehicleId]={id}";
            var client = await _context.connection.QueryFirstOrDefaultAsync<DenormalizedVehicle>(query);
            return client;
        }

        public async Task UpdateAsync(DenormalizedVehicle entity)
        {
            var query = $@"UPDATE [dbo].[DenormalizedVehicle]
                           SET [LicensePlate] = '{entity.LicensePlate}'
                              ,[ModelName] = '{entity.ModelName}'
                              ,[ModelManufacturer] = '{entity.ModelManufacturer}'
                         WHERE [VehicleId] = {entity.VehicleId}";

            await _context.connection.ExecuteAsync(query);
        }
    }
}
