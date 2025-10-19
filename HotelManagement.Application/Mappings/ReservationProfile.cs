using AutoMapper;
using HotelManagement.Application.Dtos.Reservations;
using HotelManagement.Domain.Entities;

namespace HotelManagement.Application.Mappings
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<CreateReservationDto, Reservation>();
            CreateMap<UpdateReservationDto, Reservation>();
        }
    }
}
