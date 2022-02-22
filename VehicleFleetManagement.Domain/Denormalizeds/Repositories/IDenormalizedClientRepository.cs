namespace VehicleFleetManagement.Domain.Denormalizeds.Repositories
{
    public interface IDenormalizedClientRepository : IDenormalizedRepository<DenormalizedClient>
    {
        Task UpdateAddressAsync(DenormalizedClient entity);
    }
}
