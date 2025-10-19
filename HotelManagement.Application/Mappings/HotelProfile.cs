using AutoMapper;
using HotelManagement.Application.Dtos.Hotels;
using HotelManagement.Domain.Entities;

namespace HotelManagement.Application.Mappings
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDto>()
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms))
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));

            CreateMap<CreateHotelDto, Hotel>();
            CreateMap<UpdateHotelDto, Hotel>();
        }
    }
}
