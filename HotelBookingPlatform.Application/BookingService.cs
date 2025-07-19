using HotelBookingPlatform.Core;
using HotelBookingPlatform.Core.Entities.Business;
using HotelBookingPlatform.Core.Entities.Identity;
using HotelBookingPlatform.Core.Services.Contract;
using HotelBookingPlatform.Core.Specifications;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Application
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUsers> _userManager;

        public BookingService(IUnitOfWork unitOfWork, UserManager<AppUsers> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Bookings?> CreateBookingAsync(string userEmail, Guid roomId, DateTime checkIn, DateTime checkOut, int guests)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user is null) return null;

            var booking = new Bookings
            {
                RoomId = roomId,
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                NumberOfGuests = guests,
                BookingStatus = BookingStatus.Pending,
                UserId = user.Id
            };

            await _unitOfWork.Repository<Bookings>().AddAsync(booking);
            await _unitOfWork.CompleteAsync();

            return booking;
        }

        public async Task<IReadOnlyList<Bookings>> GetBookingsForUserAsync(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null) return new List<Bookings>();

            var spec = new BookingWithRoomSpecifications(user.Id);
            return await _unitOfWork.Repository<Bookings>().GetAsyncWithSpec(spec);
        }

        public async Task<Bookings?> GetBookingByIdForUserAsync(Guid bookingId, string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null) return null;

            var spec = new BookingWithRoomSpecifications(user.Id, bookingId);
            return (await _unitOfWork.Repository<Bookings>().GetAsyncWithSpec(spec)).FirstOrDefault();
        }

    }
}
