namespace VehicleFleetManagement.Application.ViewModels.Booking
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public int ClientId { get; set; }
        public string Cpf { get; set; }
        public string ClientName { get; set; }
        public string VehicleModel { get; set; }
        public string LicensePlate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateWithdrawn { get; set; }
        public DateTime? DateExpectedWithdrawn { get; set; }
        public DateTime DateExpectedReturn { get; set; }
        public DateTime? DateReturn { get; set; }
    }
}
