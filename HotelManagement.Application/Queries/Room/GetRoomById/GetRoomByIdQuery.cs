using HotelManagement.Application.Dtos.Room;
using MediatR;

namespace HotelManagement.Application.Queries.Room.GetRoomById
{
    public sealed record GetRoomByIdQuery(Guid RoomId) : IRequest<RoomDto?>;
}
