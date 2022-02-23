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

        public async Task<List<T>> GetAllQueryAsync(string query)
        {
            var result = await _context.connection.QueryAsync<T>(query);
            return result.ToList();
        }

        public async Task UpdateQueryAsync(string query)
        {
            await _context.connection.ExecuteAsync(query);
        }

        public static string AddParameters(string query, string queryParameter)
        {
            if (query.Contains("WHERE"))
                return " AND " + queryParameter;

            return " WHERE " + queryParameter;
        }
    }
}
