namespace VehicleFleetManagement.Domain.Denormalizeds.Repositories
{
    public interface IDenormalizedBookingRepository: IDenormalizedRepository<DenormalizedBooking>
    {
        Task UpdateDateReturnAsync(DenormalizedBooking booking);
        Task UpdateDateWithdrawnAsync(int bookingId, DateTime dateWithdrawn);
        Task UpdateExpectedDateAsync(int bookingId, DateTime? dateExpectedWithdrawn, DateTime? dateExpectedReturn);
    }
}
