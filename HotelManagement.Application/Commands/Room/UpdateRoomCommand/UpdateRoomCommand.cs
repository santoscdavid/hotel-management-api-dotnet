using HotelManagement.Application.Common;
using HotelManagement.Domain.Enums;
using MediatR;

namespace HotelManagement.Application.Commands.Room.UpdateRoomCommand
{
    public sealed record UpdateRoomCommand(
        Guid RoomId,
        Guid? HotelId,
        int? Number,
        string? Type,
        decimal? PricePerNight
    ) : IRequest<Result>;
}
