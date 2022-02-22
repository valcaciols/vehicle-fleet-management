namespace VehicleFleetManagement.Application.ViewModels.Responses
{
    public class CloseBookingResponse
    {
        public int BookingId { get; set; }
        public DateTime DateReturn { get; set; }

        public CloseBookingResponse(int bookingId, DateTime dateReturn)
        {
            BookingId = bookingId;
            DateReturn = dateReturn;
        }
    }
}
