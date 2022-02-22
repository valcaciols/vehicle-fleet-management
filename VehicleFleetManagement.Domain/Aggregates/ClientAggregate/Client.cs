using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.ClientAggregate
{
    public class Client: Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Cnh { get; private set; }

        public Client(int id, string name, string cpf, DateTime birthDate, string cnh)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;
            Cnh = cnh;
        }
    }
}
