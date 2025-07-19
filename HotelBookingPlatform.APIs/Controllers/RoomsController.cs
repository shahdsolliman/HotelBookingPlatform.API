using AutoMapper;
using HotelBookingPlatform.APIs.DTOs;
using HotelBookingPlatform.Core.Entities.Business;
using HotelBookingPlatform.Core.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnapShop.API.Errors;

namespace HotelBookingPlatform.APIs.Controllers
{
    public class RoomsController : BaseAPIController
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomsController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(RoomDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("hotel/{hotelId}")] //GET: /api/rooms/hotel/{hotelId}
        public async Task<ActionResult<IReadOnlyList<RoomDto>>> GetRoomsForHotel(Guid hotelId)
        {
            var rooms = await _roomService.GetRoomsForHotelAsync(hotelId);
            if (rooms == null || !rooms.Any()) return NotFound(new ApiResponse(StatusCodes.Status404NotFound));

            return Ok(_mapper.Map<IReadOnlyList<Rooms>, IReadOnlyList<RoomDto>>(rooms));
        }

        [ProducesResponseType(typeof(RoomDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{roomId}")] //GET: /api/rooms/{roomId}
        public async Task<ActionResult<RoomDto>> GetRoomById(Guid roomId)
        {
            var room = await _roomService.GetRoomByIdAsync(roomId);
            if (room is null) return NotFound(new ApiResponse(StatusCodes.Status404NotFound));
            return Ok(_mapper.Map<Rooms, RoomDto>(room));
        }
    }
}
