using VehicleFleetManagement.Domain.SeedWork;

namespace VehicleFleetManagement.Domain.Denormalizeds
{
    public class DenormalizedClient : Entity
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cnh { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Cep { get; set; }
    }
}
