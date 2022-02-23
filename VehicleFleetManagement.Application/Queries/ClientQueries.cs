using Dapper;
using VehicleFleetManagement.Application.ViewModels.Client;
using VehicleFleetManagement.Infrastructure.Repositories;

namespace VehicleFleetManagement.Application.Queries
{
    public class ClientQueries : QueriesBase, IClientQueries
    {
        public ClientQueries(VehicleManagerContext context) : base(context)
        {
        }

        public async Task<List<ClientViewModel>> GetAllAsync(string? cpf, string? name)
        {
            if (string.IsNullOrEmpty(cpf) && string.IsNullOrEmpty(name))
                return new();
            var query = @$"SELECT * FROM [dbo].[DenormalizedClient]";

            if (!string.IsNullOrEmpty(cpf))
                query += AddParameters(query, $"[Cpf]='{cpf}'");

            if (!string.IsNullOrEmpty(name))
                query += AddParameters(query, $"[Name] LIKE '%{name}%'");

            var result = await _context.connection.QueryAsync<ClientViewModel>(query);

            return result.ToList();
        }
    }
}
