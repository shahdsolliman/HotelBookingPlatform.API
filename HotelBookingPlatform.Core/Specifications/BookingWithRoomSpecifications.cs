using HotelBookingPlatform.Core.Entities.Business;
using HotelBookingPlatform.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Specifications
{
    public class BookingWithRoomSpecifications : BaseSpecifications<Bookings>
    {
        public BookingWithRoomSpecifications(Guid userId)
            :base(b => b.UserId == userId)
        {
            Includes.Add(b => b.Room);
        }
        public BookingWithRoomSpecifications(Guid userId, Guid bookingId)
            : base(b => b.UserId == userId && b.Id == bookingId)
        {
            Includes.Add(b => b.Room);
        }
    }
}
