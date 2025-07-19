using AutoMapper;
using HotelBookingPlatform.APIs.DTOs;
using HotelBookingPlatform.APIs.Helpers;
using HotelBookingPlatform.Application;
using HotelBookingPlatform.Core.Entities.Business;
using HotelBookingPlatform.Core.Services.Contract;
using HotelBookingPlatform.Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnapShop.API.Errors;

namespace HotelBookingPlatform.APIs.Controllers
{
    public class HotelsController : BaseAPIController
    {
        private readonly IHotelSevice _hotelSevice;
        private readonly IMapper _mapper;

        public HotelsController(IHotelSevice hotelSevice, IMapper mapper)
        {
            _hotelSevice = hotelSevice;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(Pagination<HotelToReturnDto>), StatusCodes.Status200OK)]
        //[CachedAttribute(600)]
        [HttpGet] //GET: /api/hotels
        public async Task<ActionResult<HotelToReturnDto>> GetHotels([FromQuery] HotelSpecParams specParams)
        {
            var hotels = await _hotelSevice.GetHotelsAsync(specParams);
            var data = _mapper.Map<IReadOnlyList<Hotels>, IReadOnlyList<HotelToReturnDto>>(hotels);

            var count = await _hotelSevice.GetHotelsCountAsync(specParams);

            return Ok(new Pagination<HotelToReturnDto>(specParams.PageIndex, specParams.PageSize, count, data));
        }

        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")] // GET: /api/hotels/{id}
        public async Task<ActionResult<HotelToReturnDto>> GetHotelById(Guid id)
        {
            var hotel = await _hotelSevice.GetHotelByIdAsync(id);
            if (hotel is null) return NotFound(new ApiResponse(StatusCodes.Status404NotFound));
            return Ok(_mapper.Map<Hotels, HotelToReturnDto>(hotel));
        }
    }
}
