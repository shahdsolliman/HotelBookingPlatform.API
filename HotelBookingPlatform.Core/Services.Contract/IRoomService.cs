using HotelBookingPlatform.Core.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Services.Contract
{
    public interface IRoomService
    {
        Task<IReadOnlyList<Rooms>> GetRoomsForHotelAsync(Guid hotelId);
        Task<Rooms?> GetRoomByIdAsync(Guid roomId);
    }
}
