using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Aggregates.ClientAggregate
{
    public class Address: Entity
    {
        public int ClientId { get; set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public int Cep { get; private set; }

        public Address()
        {

        }

        public Address(int clientId, string street, string city, int? cep)
        {
            ClientId = clientId;
            Street = street;
            City = city;
            Cep = cep.HasValue ? cep.Value: 0;
        }

        public void Change(string street, string city, int? cep)
        {
            Street = street == null || Street.Equals(street) ? Street : street;
            City = city == null || City.Equals(city) ? City : city;
            Cep = !cep.HasValue ||Cep.Equals(cep) || cep == 0 ? Cep : cep.Value;
        }        
    }
}
