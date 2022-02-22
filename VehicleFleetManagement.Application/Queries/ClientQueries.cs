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

            var queryBase = @$"SELECT * FROM [dbo].[DenormalizedClient] ";
            var query = string.Empty;

            if (!string.IsNullOrEmpty(cpf))
            {
                query = $" WHERE [Cpf]='{cpf}'";
            }
            
            if (!string.IsNullOrEmpty(name))
            {
                query += query == string.Empty ? " WHERE": " AND";
                query += $" [Name] like '%{name}%'";
            }

            if (string.IsNullOrEmpty(query))
                return new();

            var result = await _context.connection.QueryAsync<ClientViewModel>(queryBase + query);

            return result.ToList();
        }
    }
}
