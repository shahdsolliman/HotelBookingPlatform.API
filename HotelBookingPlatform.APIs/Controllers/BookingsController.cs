using AutoMapper;
using HotelBookingPlatform.APIs.DTOs;
using HotelBookingPlatform.APIs.Helpers;
using HotelBookingPlatform.Core.Entities.Business;
using HotelBookingPlatform.Core.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnapShop.API.Errors;

namespace HotelBookingPlatform.APIs.Controllers
{
    public class BookingsController : BaseAPIController
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]   //POST: api/bookings
        [ProducesResponseType(typeof(BookingToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookingToReturnDto>> CreateBooking(string email, BookingDto bookingDto)
        {
            var booking = await _bookingService.CreateBookingAsync(
                email,
                bookingDto.RoomId,
                bookingDto.CheckInDate,
                bookingDto.CheckOutDate,
                bookingDto.NumberOfGuests
            );

            if (booking is null) return BadRequest(new ApiResponse(StatusCodes.Status400BadRequest));

            return Ok(_mapper.Map<Bookings, BookingToReturnDto>(booking));
        }

        [Authorize] // Ensure the user is authenticated
        [ProducesResponseType(typeof(BookingToReturnDto), StatusCodes.Status200OK)]
        //[Cached(600)] // Cache for 10 minutes
        [HttpGet] //GET: api/bookings
        public async Task<ActionResult<IReadOnlyList<BookingToReturnDto>>> GetBookingsForUser(string email)
        {
            var bookings = await _bookingService.GetBookingsForUserAsync(email);
            return Ok(_mapper.Map<IReadOnlyList<Bookings>, IReadOnlyList<BookingToReturnDto>>(bookings));
        }

        [Authorize]
        [ProducesResponseType(typeof(BookingToReturnDto), StatusCodes.Status200OK)]
        //[Cached(600)] // Cache for 10 minutes
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingToReturnDto>> GetBookingById(Guid id, string email)
        {
            var booking = await _bookingService.GetBookingByIdForUserAsync(id, email);
            if (booking == null) return NotFound(new ApiResponse(StatusCodes.Status404NotFound));
            return Ok(_mapper.Map<Bookings, BookingToReturnDto>(booking));
        }
    }
}
