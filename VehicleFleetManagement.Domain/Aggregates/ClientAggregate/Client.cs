using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.ClientAggregate
{
    public class Client: Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public int Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int Cnh { get; private set; }
        public int AddressId { get; private set; }
        public Address Address { get; private set; }

        public Client(string name, int cpf, DateTime birthDate, int cnh, Address address)
        {
            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;
            Cnh = cnh;
            Address = address;
            AddressId = address.Id;
        }

        public void ChangeAddress(string street, string city, int cep)
        {
            Address.Change(street, city, cep);
        }
    }
}
