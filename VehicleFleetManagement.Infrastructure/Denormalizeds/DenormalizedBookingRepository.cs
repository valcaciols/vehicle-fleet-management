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
                       ,[Cpf]
                       ,[ClientName]
                       ,[VehicleId]
                       ,[VehicleModel]
                       ,[LicensePlate]
                       ,[BookingId]
                       ,[DateCreated]
                       ,[DateExpectedWithdrawn]
                       ,[DateExpectedReturn])
                     VALUES
                           ({entity.ClientId}
                           ,'{entity.Cpf}'
                           ,'{entity.ClientName}'
                           ,{entity.VehicleId}
                           ,'{entity.VehicleModel}'
                           ,'{entity.LicensePlate}'
                           ,{entity.BookingId}
                           ,'{entity.DateCreated}'
                           ,'{entity.DateExpectedWithdrawn}'
                           ,'{entity.DateExpectedReturn}')";

            query += "SELECT CAST(SCOPE_IDENTITY() as int)";

            await _context.connection.ExecuteAsync(query);
        }

        public async Task<DenormalizedBooking> GetAsync(int id)
        {
            var query = $"SELECT * FROM [DenormalizedBooking].[dbo].[DenormalizedClient] WHERE [BookingId]={id}";
            var client = await _context.connection.QueryFirstOrDefaultAsync<DenormalizedBooking>(query);
            return client;
        }

        public async Task UpdateAsync(DenormalizedBooking entity)
        {
            var query = $@"UPDATE [dbo].[DenormalizedBooking]
                           SET [ClientId] = {entity.ClientId}
                              ,[ClientName] = '{entity.ClientName}'
                              ,[VehicleId] = {entity.VehicleId}
                              ,[VehicleModel] = '{entity.VehicleModel}'
                              ,[LicensePlate] = '{entity.LicensePlate}'
                              ,[DateWithdrawn] = '{entity.DateWithdrawn}'
                              ,[DateWithdrawn] = '{entity.DateWithdrawn}'
                         WHERE [BookingId]={entity.BookingId}";

            await _context.connection.ExecuteAsync(query);
        }

        public async Task UpdateDateReturnAsync(DenormalizedBooking booking)
        {
            var query = $@"UPDATE [dbo].[DenormalizedBooking]
                           SET [DateReturn] = '{booking.DateReturn}'
                         WHERE [BookingId]={ booking.BookingId }";

            await _context.connection.ExecuteAsync(query);
        }
    }
}
