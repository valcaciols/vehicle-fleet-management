using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFleetManagement.Infrastructure.Repositories;

namespace VehicleFleetManagement.Application.Queries
{
    public class QueriesBase : IQueries
    {
        protected readonly VehicleManagerContext _context;

        public QueriesBase(VehicleManagerContext context)
        {
            _context = context;
        }

        public static string AddParameters(string query, string queryParameter)
        {
            if (query.Contains("WHERE"))
                return " AND " + queryParameter;

            return " WHERE " + queryParameter;
        }
    }
}
