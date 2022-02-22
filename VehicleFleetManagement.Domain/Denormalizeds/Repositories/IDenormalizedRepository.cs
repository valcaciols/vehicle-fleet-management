namespace VehicleFleetManagement.Domain.Denormalizeds.Repositories
{
    public interface IDenormalizedRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T>GetAsync(int id);
    }
}
