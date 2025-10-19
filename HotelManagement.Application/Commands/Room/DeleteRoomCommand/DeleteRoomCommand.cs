using HotelManagement.Application.Common;
using MediatR;

namespace HotelManagement.Application.Commands.Room.DeleteRoomCommand
{
    public sealed record DeleteRoomCommand(
        Guid RoomId
    ) : IRequest<Result>;
}
