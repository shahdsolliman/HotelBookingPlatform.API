using HotelBookingPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Entities.Business
{
    public class Rooms : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public RoomType RoomType { get; set; }

        public Guid HotelId { get; set; } // Foreign key for Hotel
        public Hotels Hotel { get; set; } // Navigation property One-to-One relationship with Hotel

        public ICollection<Bookings> Bookings { get; set; } = new HashSet<Bookings>(); // Navigation property One-to-Many relationship with Booking
    }
}
