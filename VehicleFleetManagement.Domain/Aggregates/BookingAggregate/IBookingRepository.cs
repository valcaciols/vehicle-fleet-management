namespace VehicleFleetManagement.Domain.Aggregates.BookingAggregate
{
    public interface IBookingRepository
    {
        Task<Booking> GetAsync(int bookingId);
        Task UpdateDateReturnAsync(int bookingId, DateTime dateReturn);
        Task UpdateDateWithdrawnAsync(int bookingId, DateTime dateWithdrawn);
        Task UpdateExpectedDateAsync(int bookingId, DateTime? dateExpectedWithdrawn, DateTime? dateExpectedReturn);
        Task<List<Booking>> GetAllByClientIdAsync(int clientId);
        Task<Booking> AddAsync(Booking booking);
        Task<bool> ExistActiveByClientId(int clientId);
    }
}
