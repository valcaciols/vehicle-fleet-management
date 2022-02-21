namespace VehicleFleetManagement.Application.ViewModels.Responses
{
    public class ClientResponse
    {
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Cnh { get; private set; }

        public ClientResponse(string name, string cpf, string cnh, DateTime birthDate)
        {
            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;
            Cnh = cnh;
        }
    }
}
