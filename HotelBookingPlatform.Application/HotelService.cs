using AutoMapper;
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
    public class HotelService : IHotelSevice
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Hotels?> GetHotelByIdAsync(Guid id)
        {
            var spec = new HotelsWithRoomsSpecification(id);
            var hotels = await _unitOfWork.Repository<Hotels>().GetAsyncWithSpec(spec);
            return hotels.FirstOrDefault();
        }
        public async Task<IReadOnlyList<Hotels>> GetHotelsAsync(HotelSpecParams specParams)
        {
            var spec = new HotelsWithRoomsSpecification(specParams);
            return await _unitOfWork.Repository<Hotels>().GetAsyncWithSpec(spec);
        }

        public async Task<int> GetHotelsCountAsync(HotelSpecParams specParams)
        {
            var countSpec = new HotelsWithRoomsSpecification(specParams); // or another minimal spec
            var hotels = await _unitOfWork.Repository<Hotels>().GetAsyncWithSpec(countSpec);
            return hotels.Count;
        }
    }
}
