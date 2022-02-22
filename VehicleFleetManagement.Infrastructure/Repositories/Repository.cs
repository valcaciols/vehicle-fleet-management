using Dapper;
using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class Repository<T>: IRepository
    {
        protected readonly VehicleManagerContext _context;

        public Repository(VehicleManagerContext context)
        {
            _context = context;
        }

        public async Task<T> GetQueryAsync(string query)
        {
            return await _context.connection.QueryFirstOrDefaultAsync<T>(query);
        }

        public async Task<int> AddQueryAsync(string query)
        {
            query += "SELECT CAST(SCOPE_IDENTITY() as int)";
            return await _context.connection.QuerySingleAsync<int>(query);
        }

        public async Task UpdateQueryAsync(string query)
        {
            await _context.connection.ExecuteAsync(query);
        }
    }
}
