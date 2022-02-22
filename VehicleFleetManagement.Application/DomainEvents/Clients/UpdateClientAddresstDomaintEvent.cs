using MediatR;

namespace VehicleFleetManagement.Application.DomainEvents.Clients
{
    public class UpdateClientAddresstDomaintEvent : INotification
    {
        public int ClientId { get; set; }
        public int AddressId { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public int Cep { get; set; }
    }
}
