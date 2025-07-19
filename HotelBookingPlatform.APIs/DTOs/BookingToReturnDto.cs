namespace HotelBookingPlatform.APIs.DTOs
{
    public class BookingToReturnDto
    {
        public Guid Id { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public string BookingStatus { get; set; }

    }
}
