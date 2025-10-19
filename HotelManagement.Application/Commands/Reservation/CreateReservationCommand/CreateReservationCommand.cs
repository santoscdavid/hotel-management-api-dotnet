using HotelManagement.Application.Common;
using MediatR;

namespace HotelManagement.Application.Commands.Reservation.CreateReservationCommand
{
    public sealed record CreateReservationCommand(
        Guid RoomId,
        Guid GuestId,
        DateTime CheckIn,
        DateTime CheckOut,
        decimal TotalPrice)
        : IRequest<Result<Guid>>;
}