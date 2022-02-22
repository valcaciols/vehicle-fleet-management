using Dapper;
using VehicleFleetManagement.Domain.Denormalizeds;
using VehicleFleetManagement.Domain.Denormalizeds.Repositories;
using VehicleFleetManagement.Infrastructure.Repositories;

namespace VehicleFleetManagement.Infrastructure.Denormalizeds
{
    public class DenormalizedBookingRepository : IDenormalizedBookingRepository
    {
        private readonly VehicleManagerContext _context;

        public DenormalizedBookingRepository(VehicleManagerContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DenormalizedBooking entity)
        {
            var query = $@"INSERT INTO [dbo].[DenormalizedBooking]
                       ([ClientId]
                       ,[ClientName]
                       ,[VehicleId]
                       ,[VehicleModel]
                       ,[LicensePlate]
                       ,[BookingId]
                       ,[DateCreated]
                       ,[DateWithdrawn]
                       ,[DateExpectedReturn])
                     VALUES
                           ({entity.ClientId}
                           ,'{entity.ClientName}'
                           ,{entity.VehicleId}
                           ,'{entity.VehicleModel}'
                           ,'{entity.LicensePlate}'
                           ,{entity.BookingId}
                           ,'{entity.DateCreated}'
                           ,'{entity.DateWithdrawn}'
                           ,'{entity.DateExpectedReturn}')";

            query += "SELECT CAST(SCOPE_IDENTITY() as int)";

            await _context.connection.ExecuteAsync(query);
        }

        public Task<DenormalizedBooking> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DenormalizedBooking entity)
        {
            throw new NotImplementedException();
        }
    }
}
