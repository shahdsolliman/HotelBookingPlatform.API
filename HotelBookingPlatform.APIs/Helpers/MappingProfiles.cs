using AutoMapper;
using HotelBookingPlatform.APIs.DTOs;
using HotelBookingPlatform.Core.Entities.Business;

namespace HotelBookingPlatform.APIs.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Rooms, RoomDto>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType.ToString()));

            CreateMap<Address, AddressDto>();

            CreateMap<Hotels, HotelToReturnDto>()
                .ForMember(dest => dest.StarRating, opt => opt.MapFrom(src => src.StarRating.ToString()))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms));

            CreateMap<Rooms, RoomDto>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType.ToString()));

            CreateMap<Bookings, BookingToReturnDto>()
                .ForMember(dest => dest.PricePerNight, opt => opt.MapFrom(src => src.Room.PricePerNight))
                .ForMember(dest => dest.BookingStatus, opt => opt.MapFrom(src => src.BookingStatus.ToString()));


        }
    }
}
