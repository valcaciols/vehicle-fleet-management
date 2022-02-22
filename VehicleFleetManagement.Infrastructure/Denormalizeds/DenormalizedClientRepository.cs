using Dapper;
using VehicleFleetManagement.Domain.Denormalizeds;
using VehicleFleetManagement.Domain.Denormalizeds.Repositories;
using VehicleFleetManagement.Infrastructure.Repositories;

namespace VehicleFleetManagement.Infrastructure.Denormalizeds
{
    public class DenormalizedClientRepository : IDenormalizedClientRepository
    {
        private readonly VehicleManagerContext _context;

        public DenormalizedClientRepository(VehicleManagerContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DenormalizedClient entity)
        {
            var query = $@"INSERT INTO [dbo].[DenormalizedClient]
                           ([ClientId]
                           ,[Name]
                           ,[Cpf]
                           ,[Cnh]
                           ,[BirthDate]
                           ,[Street]
                           ,[City]
                           ,[Cep])
                     VALUES
                           ({entity.ClientId}
                           ,'{entity.Name}'
                           ,'{entity.Cpf}'
                           ,'{entity.Cnh}'
                           ,'{entity.BirthDate}'
                           ,'{entity.Street}'
                           ,'{entity.City}'
                           ,'{entity.Cep}')";

            query += "SELECT CAST(SCOPE_IDENTITY() as int)";

            await _context.connection.ExecuteAsync(query);
        }

        public async Task<DenormalizedClient> GetAsync(int id)
        {
            var query = $"SELECT * FROM [VehicleManagement].[dbo].[DenormalizedClient] WHERE [ClientId]={id}";
            var client = await _context.connection.QueryFirstOrDefaultAsync<DenormalizedClient>(query);
            return client;
        }

        public async Task UpdateAsync(DenormalizedClient entity)
        {
            var query = $@"UPDATE [dbo].[DenormalizedClient]
                           SET [Name] = '{entity.Name}'
                              ,[Cpf] = '{entity.Cpf}'
                              ,[Cnh] = '{entity.Cnh}'
                              ,[BirthDate] = '{entity.BirthDate}'
                              ,[Street] = '{entity.Street}'
                              ,[City] = '{entity.City}'
                              ,[Cep] = {entity.Cep}
                         WHERE [ClientId] = {entity.ClientId}";

            await _context.connection.ExecuteAsync(query);
        }

        public async Task UpdateAddressAsync(DenormalizedClient entity)
        {
            var query = $@"UPDATE [dbo].[DenormalizedClient]
                           SET [Street] = '{entity.Street}'
                              ,[City] = '{entity.City}'
                              ,[Cep] = {entity.Cep}
                         WHERE [ClientId] = {entity.ClientId}";

            await _context.connection.ExecuteAsync(query);
        }
    }
}
