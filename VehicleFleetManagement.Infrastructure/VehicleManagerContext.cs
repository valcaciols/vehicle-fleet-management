using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VehicleFleetManagement.Infrastructure.Repositories
{
    public class VehicleManagerContext : DbContext, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public readonly IDbConnection connection;

        public VehicleManagerContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("VehicleManagement");
            this.connection = CreateConnection();
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public override void Dispose()
        {
            this.connection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
