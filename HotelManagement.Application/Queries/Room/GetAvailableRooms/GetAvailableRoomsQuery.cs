using HotelManagement.Application.Dtos.Room;
using MediatR;

namespace HotelManagement.Application.Queries.Room.GetAvailableRooms
{
    public sealed record GetAvailableRoomsQuery(Guid HotelId) : IRequest<IEnumerable<RoomDto>> { }
}
