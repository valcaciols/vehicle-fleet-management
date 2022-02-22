using VehicleFleetManagement.Domain.Aggregates.BookingAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private static List<Booking> _bookings = new();
        public async Task<Booking> AddAsync(Booking booking)
        {
            _bookings.Add(booking);
            return await Task.FromResult(booking);
        }

        public async Task<bool> ExistActiveByClientId(int clientId)
        {
            var exist = _bookings.Any(a => a.ClientId == clientId && a.DateReturn == null);
            return await Task.FromResult(exist);
        }

        public async Task<List<Booking>> GetAllByClientIdAsync()
        {
            return await Task.FromResult(_bookings);
        }
    }
}
