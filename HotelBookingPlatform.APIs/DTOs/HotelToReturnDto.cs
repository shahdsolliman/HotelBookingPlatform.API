namespace HotelBookingPlatform.APIs.DTOs
{
    public class HotelToReturnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string StarRating { get; set; } // because it's Enum as string
        public AddressDto Address { get; set; }
        public IReadOnlyList<RoomDto> Rooms { get; set; }
    }
}
