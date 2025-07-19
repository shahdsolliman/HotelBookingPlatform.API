using HotelBookingPlatform.Core.Entities.Business;
using HotelBookingPlatform.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingPlatform.Core.Services.Contract
{
    public interface IHotelSevice
    {
        Task<IReadOnlyList<Hotels>> GetHotelsAsync(HotelSpecParams specParams);
        Task<Hotels?> GetHotelByIdAsync(Guid id);
        Task<int> GetHotelsCountAsync(HotelSpecParams specParams);
    }
}
