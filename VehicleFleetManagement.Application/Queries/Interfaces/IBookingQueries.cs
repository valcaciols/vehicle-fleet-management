using VehicleFleetManagement.Application.ViewModels.Booking;

namespace VehicleFleetManagement.Application.Queries
{
    public interface IBookingQueries : IQueries
    {
        Task<List<BookingViewModel>> GetAllAsync(int? clientId, string? cpf, string? name);
        Task<List<BookingViewModel>> GetAllWithdrawnAsync(DateTime? inicialDate, DateTime? endDate);
    }
}
