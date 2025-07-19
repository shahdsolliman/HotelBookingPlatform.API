namespace HotelBookingPlatform.APIs.DTOs
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string RoomNumber { get; set; }
        public decimal PricePerNight { get; set; }
        public string RoomType { get; set; } // Enum
        public bool IsAvailable { get; set; }
    }
}
