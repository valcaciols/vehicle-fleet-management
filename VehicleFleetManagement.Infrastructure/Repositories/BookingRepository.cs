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
                               ,[DateWithdrawn]
                               ,[DateExpectedReturn])
                         VALUES
                               ({booking.ClientId}
                               ,{booking.VehicleId}
                               ,'{booking.DateCreated}'
                               ,'{booking.DateWithdrawn}'
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
    }
}
