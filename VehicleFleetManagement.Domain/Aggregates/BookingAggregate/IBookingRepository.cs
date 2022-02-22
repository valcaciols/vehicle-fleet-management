namespace VehicleFleetManagement.Domain.Aggregates.BookingAggregate
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllByClientIdAsync(int clientId);
        Task<Booking> AddAsync(Booking booking);
        Task<bool> ExistActiveByClientId(int clientId);
    }
}
