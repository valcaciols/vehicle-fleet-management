namespace VehicleFleetManagement.Domain.Denormalizeds.Repositories
{
    public interface IDenormalizedBookingRepository: IDenormalizedRepository<DenormalizedBooking>
    {
        Task UpdateDateReturnAsync(DenormalizedBooking booking);
    }
}
