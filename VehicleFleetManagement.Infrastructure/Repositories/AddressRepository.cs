using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(VehicleManagerContext context) : base(context)
        {
        }

        public async Task<Address> AddAsync(Address address)
        {
            var query = $@"INSERT INTO [dbo].[Address]
                           ([ClientId]
                           ,[Street]
                           ,[City]
                           ,[Cep])
                     VALUES
                           ({address.ClientId}
                           ,'{address.Street}'
                           ,'{address.City}'
                           ,{address.Cep})";

            address.Id = await AddQueryAsync(query);
            return address;
        }

        public async Task<Address?> GetByClientIdAsync(int clientId)
        {
            var query = $@"SELECT * FROM [dbo].[Address] WHERE [ClientId]={clientId}";
            return await GetQueryAsync(query);
        }

        public async Task UpdateAddressAsync(Address address)
        {
            var addressChange = await GetByClientIdAsync(address.ClientId);

            if (addressChange == null)
                return;

            addressChange.Change(address.Street, address.City, address.Cep);

            var query = $@"UPDATE [dbo].[Address]
                           SET [Street] = '{addressChange.Street}'
                              ,[City] = '{addressChange.City}'
                              ,[Cep] = {address.Cep}
                         WHERE [ClientId]={address.ClientId}";

            await UpdateQueryAsync(query);
        }
    }
}
