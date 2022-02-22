using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(VehicleManagerContext context) : base(context)
        {
        }

        public async Task<Client> AddAsync(Client client)
        {
            var query = $@"INSERT INTO [dbo].[Client]
                               ([Name]
                               ,[Cpf]
                               ,[Cnh]
                               ,[BirthDate])
                         VALUES
                               ('{client.Name}'
                               ,'{client.Cpf}'
                               ,'{client.Cnh}'
                               ,'{client.BirthDate}')";

            client.Id = await AddQueryAsync(query);
            return client;
        }

        public async Task<bool> ExistAsync(string cpf, string cnh)
        {
            if(string.IsNullOrEmpty(cpf) && string.IsNullOrEmpty(cnh))
                return false;

            var queryBase = "SELECT * FROM [dbo].[Client] WHERE";
            var query = string.Empty;

            if (!string.IsNullOrEmpty(cpf))
            {
                query = $"{queryBase} [Cpf]={cpf}";
            }
            else if (!string.IsNullOrEmpty(cnh))
            {
                query = $"{queryBase} [Cnh]={cnh}";
            }

            if(string.IsNullOrEmpty(query))
                return false;

            var result = await GetQueryAsync(query);

            if (result == null)
                return false;

            return true;
        }

        public async Task<bool> ExistAsync(int clientId)
        {
            var query = $@"SELECT * FROM [dbo].[Client] WHERE [Id]={clientId}";
            var result = await GetQueryAsync(query);
            return result != null;
        }

        public async Task<List<Client>> GetAllAsync(string cpf, string name)
        {
            if (string.IsNullOrEmpty(cpf) && string.IsNullOrEmpty(name))
                return new();

            var queryBase = "SELECT * FROM [dbo].[Client] WHERE";
            var query = string.Empty;
            
            if (string.IsNullOrEmpty(cpf) && string.IsNullOrEmpty(name))
            {
                query = $"{queryBase} [Cpf]={cpf} AND [Cnh]={name}";
            }
            else if (!string.IsNullOrEmpty(cpf))
            {
                query = $"{queryBase} [Cpf]={cpf}";
            }
            else if (!string.IsNullOrEmpty(name))
            {
                query = $"{queryBase} [Cnh]={name}";
            }

            return await GetAllQueryAsync(query);
        }

        public async Task<Client?> GetAsync(int id)
        {
            var query = $@"SELECT * FROM [dbo].[Client] WHERE [Id]={id}";
            return await GetQueryAsync(query);
        }
    }
}
