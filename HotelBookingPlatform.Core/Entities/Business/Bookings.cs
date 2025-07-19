using HotelBookingPlatform.Core.Entities.Identity;
using HotelBookingPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Entities.Business
{
    public class Bookings : BaseEntity
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public BookingStatus BookingStatus { get; set; }

        public Guid RoomId { get; set; } // Foreign key to Room
        public Rooms Room { get; set; } //  Navigation property One-to-One relationship with Room

        public Guid UserId { get; set; } // Foreign key to AppUser
    }
}
