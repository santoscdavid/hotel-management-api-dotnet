using AutoMapper;
using HotelManagement.Application.Dtos.Room;
using HotelManagement.Application.Dtos.Rooms;
using HotelManagement.Domain.Entities;

namespace HotelManagement.Application.Mappings
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<CreateRoomDto, Room>();
            CreateMap<UpdateRoomDto, Room>();
            CreateMap<Room, RoomSummaryDto>();
        }
    }
}
