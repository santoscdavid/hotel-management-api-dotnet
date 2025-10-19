using AutoMapper;
using HotelManagement.Application.Dtos.Guests;
using HotelManagement.Domain.Entities;

namespace HotelManagement.Application.Mappings
{
    public class GuestProfile : Profile
    {
        public GuestProfile()
        {
            CreateMap<Guest, GuestDto>().ReverseMap();
            CreateMap<CreateGuestDto, Guest>();
            CreateMap<UpdateGuestDto, Guest>();
        }
    }
}
