namespace VehicleFleetManagement.Domain.Aggregates.BookingAggregate
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllByClientIdAsync();
        Task<Booking> AddAsync(Booking booking);
    }
}
