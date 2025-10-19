using HotelManagement.Application.Dtos.Room;
using MediatR;

namespace HotelManagement.Application.Queries.Room.GetAllRooms
{
    public sealed record GetAllRoomsQuery : IRequest<IEnumerable<RoomDto>> {}
}
