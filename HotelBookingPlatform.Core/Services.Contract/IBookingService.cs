using HotelBookingPlatform.Core.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Services.Contract
{
    public interface IBookingService
    {
        Task<IReadOnlyList<Bookings>> GetBookingsForUserAsync(string userEmail);
        Task<Bookings?> GetBookingByIdForUserAsync(Guid bookingId, string userEmail);
        Task<Bookings?> CreateBookingAsync(string userEmail, Guid roomId, DateTime checkIn, DateTime checkOut, int guests);

    }
}
