namespace HotelBookingPlatform.APIs.DTOs
{
    public class BookingDto
    {
        public Guid RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
