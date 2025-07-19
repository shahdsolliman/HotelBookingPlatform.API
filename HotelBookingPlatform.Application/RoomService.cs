using HotelBookingPlatform.Core;
using HotelBookingPlatform.Core.Entities.Business;
using HotelBookingPlatform.Core.Services.Contract;
using HotelBookingPlatform.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Application
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<Rooms>> GetRoomsForHotelAsync(Guid hotelId)
        {
            var spec = new RoomsForHotelSpec(hotelId);
            return await _unitOfWork.Repository<Rooms>().GetAsyncWithSpec(spec);
        }
        public async Task<Rooms?> GetRoomByIdAsync(Guid roomId)
        {
            return await _unitOfWork.Repository<Rooms>().GetByIdAsync(roomId);
        }
    }
}
