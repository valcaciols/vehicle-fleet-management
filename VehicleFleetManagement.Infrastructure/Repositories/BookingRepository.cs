using VehicleFleetManagement.Domain.Aggregates.BookingAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(VehicleManagerContext context) : base(context)
        {
        }

        public async Task<Booking> AddAsync(Booking booking)
        {
            var query = $@"INSERT INTO [dbo].[Booking]
                               ([ClientId]
                               ,[VehicleId]
                               ,[DateCreated]
                               ,[DateExpectedWithdrawn]
                               ,[DateExpectedReturn])
                         VALUES
                               ({booking.ClientId}
                               ,{booking.VehicleId}
                               ,'{booking.DateCreated}'
                               ,'{booking.DateExpectedWithdrawn}'
                               ,'{booking.DateExpectedReturn}')";

            booking.Id = await AddQueryAsync(query);
            return booking;
        }

        public async Task<bool> ExistActiveByClientId(int clientId)
        {
            var query = $@"SELECT * FROM [dbo].[Booking] WHERE [ClientId]={clientId} AND [DateReturn] IS NULL";
            var result = await GetQueryAsync(query);
            return result != null;
        }

        public async Task<List<Booking>> GetAllByClientIdAsync(int clientId)
        {
            var query = $@"SELECT * FROM [dbo].[Booking] WHERE [ClientId]={clientId}";
            return await GetAllQueryAsync(query);
        }

        public async Task<Booking> GetAsync(int bookingId)
        {
            var query = $@"SELECT * FROM [dbo].[Booking] WHERE [Id]={bookingId}";
            return await GetQueryAsync(query);
        }

        public async Task UpdateDateReturnAsync(int bookingId, DateTime dateReturn)
        {
            var query = $@"UPDATE [dbo].[Booking]
                           SET [DateReturn] = '{dateReturn}'
                         WHERE [Id]={ bookingId }";

            await UpdateQueryAsync(query);
        }

        public async Task UpdateExpectedDateAsync(int bookingId, DateTime? dateExpectedWithdrawn, DateTime? dateExpectedReturn)
        {
            if(dateExpectedWithdrawn == null && dateExpectedReturn == null)
                return;

            var query = $@"UPDATE [dbo].[Booking] SET ";

            var parameters = string.Empty;

            if (dateExpectedWithdrawn.HasValue)
                parameters += $"[DateExpectedWithdrawn] = '{dateExpectedWithdrawn.Value}'";

            if (dateExpectedReturn.HasValue)
            {
                parameters += string.IsNullOrEmpty(parameters) ? "" : " ,";
                parameters += $"[DateExpectedReturn] = '{dateExpectedReturn.Value}'";
            }
                
            query += parameters + $" WHERE [Id]={ bookingId }";
            await UpdateQueryAsync(query);
        }
    }
}
