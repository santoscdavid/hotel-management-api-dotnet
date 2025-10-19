using HotelManagement.Application.Common;
using HotelManagement.Domain.Enums;
using MediatR;

namespace HotelManagement.Application.Commands.Room.CreateRoomCommand
{
    public sealed record CreateRoomCommand(
        Guid HotelId,
        int Number,
        decimal PricePerNight,
        string RoomType
    ) : IRequest<Result<Guid>>;
}
