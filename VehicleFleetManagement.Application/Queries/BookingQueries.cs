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
    }
}
