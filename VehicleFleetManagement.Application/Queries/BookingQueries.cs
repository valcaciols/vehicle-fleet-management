using Dapper;
using VehicleFleetManagement.Application.ViewModels.Booking;
using VehicleFleetManagement.Infrastructure.Repositories;

namespace VehicleFleetManagement.Application.Queries
{
    public class BookingQueries : QueriesBase, IBookingQueries
    {
        public BookingQueries(VehicleManagerContext context) : base(context)
        {
        }

        public async Task<List<BookingViewModel>> GetAllAsync(int? clientId, string? cpf, string? name)
        {
            var query = $@"SELECT * FROM [dbo].[DenormalizedBooking]";

            if (clientId.HasValue)
                query += AddParameters(query, $"[ClientId]={clientId}");

            if (!string.IsNullOrEmpty(cpf))
                query += AddParameters(query, $"[Cpf] LIKE '%{cpf}%'");

            if (!string.IsNullOrEmpty(name))
                query += AddParameters(query, $"[ClientName] LIKE '%{name}%'");

            var result = await _context.connection.QueryAsync<BookingViewModel>(query);

            return result.ToList();
        }

        public async Task<List<BookingViewModel>> GetAllExpiredAsync(DateTime withdrawnDate)
        {
            var query = $@"SELECT * FROM [dbo].[DenormalizedBooking] WHERE [DateWithdrawn] IS NULL";

            query += AddParameters(query, $"[DateExpectedReturn] < '{withdrawnDate}'");

            var result = await _context.connection.QueryAsync<BookingViewModel>(query);

            return result.ToList();
        }

        public async Task<List<BookingViewModel>> GetAllWithdrawnAsync(DateTime? inicialDate, DateTime? endDate)
        {
            var query = $@"SELECT * FROM [dbo].[DenormalizedBooking] WHERE [DateWithdrawn] IS NOT NULL";

            if (inicialDate.HasValue)
                query += AddParameters(query, $"[DateWithdrawn] >= '{inicialDate}'");

            if (endDate.HasValue)
                query += AddParameters(query, $"[DateWithdrawn] <= '{endDate}'");

            var result = await _context.connection.QueryAsync<BookingViewModel>(query);

            return result.ToList();
        }
    }
}
