using VehicleFleetManagement.Domain.Aggregates.BookingAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private List<Booking> _bookings = new();
        public async Task<Booking> AddAsync(Booking booking)
        {
            _bookings.Add(booking);
            return await Task.FromResult(booking);
        }

        public async Task<bool> ExistActiveByClientId(int clientId)
        {
            return await Task.FromResult(false);
        }

        public async Task<List<Booking>> GetAllByClientIdAsync()
        {
            return await Task.FromResult(_bookings);
        }
    }
}
