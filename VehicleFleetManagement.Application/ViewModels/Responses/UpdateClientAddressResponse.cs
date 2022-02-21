namespace VehicleFleetManagement.Application.ViewModels.Responses
{
    public class UpdateClientAddressResponse
    {
        public string ClientName { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public int Cep { get; private set; }

        public UpdateClientAddressResponse(string clientName, string street, string city, int cep)
        {
            ClientName = clientName;
            Street = street;
            City = city;
            Cep = cep;
        }
    }
}
