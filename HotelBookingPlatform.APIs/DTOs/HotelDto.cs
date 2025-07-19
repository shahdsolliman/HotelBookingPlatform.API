namespace HotelBookingPlatform.APIs.DTOs
{
    public class HotelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string StarRating { get; set; } // Enum as string
        public ICollection<RoomDto> Rooms { get; set; }
    }
}
