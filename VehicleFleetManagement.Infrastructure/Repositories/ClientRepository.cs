using VehicleFleetManagement.Domain.Aggregates.ClientAggregate;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private static List<Client> _clients = new()
        {
            new Client(0, "Leonardo", "01883806208", DateTime.Now, "67631321"),
            new Client(1, "Joao", "45454545454", DateTime.Now, "5576431"),
            new Client(2, "Maria", "268975654", DateTime.Now, "448761"),
            new Client(3, "Sthe", "78797911", DateTime.Now, "64687")
        };

        public ClientRepository(VehicleManagerContext context) : base(context)
        {
        }

        public async Task<Client> AddAsync(Client client)
        {
            _clients.Add(client);
            return await Task.FromResult(client);
        }

        public async Task<bool> ExistAsync(string cpf, string cnh)
        {
            if(string.IsNullOrEmpty(cpf) && string.IsNullOrEmpty(cnh))
                return false;

            var query = _clients.AsQueryable();

            if (!string.IsNullOrEmpty(cpf))
            {
                query = query.Where(w => w.Cpf == cpf);
            }

            if (!string.IsNullOrEmpty(cnh))
            {
                query = query.Where(w => w.Cnh == cnh);
            }

            return await Task.FromResult(query.Any());
        }

        public async Task<bool> ExistAsync(int clientId)
        {
            return await Task.FromResult(false);
        }

        public async Task<List<Client>> GetAllAsync(string cpf, string name)
        {
            if (string.IsNullOrEmpty(cpf) && name == null)
                return new();

            var query = _clients.AsQueryable();

            if (!string.IsNullOrEmpty(cpf))
            {
                query = query.Where(w => w.Cpf == cpf);
            }

            if (name != null)
            {
                query = query.Where(w => w.Name.Contains(name));
            }

            return await Task.FromResult(query.ToList());
        }

        public async Task<Client?> GetAsync(int id)
        {
            return await Task.FromResult(_clients.Find(w => w.Id == id));
        }
    }
}
