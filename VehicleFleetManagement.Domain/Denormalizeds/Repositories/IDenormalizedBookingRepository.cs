namespace VehicleFleetManagement.Domain.Denormalizeds.Repositories
{
    public interface IDenormalizedBookingRepository: IDenormalizedRepository<DenormalizedBooking>
    {
        Task UpdateDateReturnAsync(DenormalizedBooking booking);
        Task UpdateExpectedDateAsync(int bookingId, DateTime? dateExpectedWithdrawn, DateTime? dateExpectedReturn);
    }
}
