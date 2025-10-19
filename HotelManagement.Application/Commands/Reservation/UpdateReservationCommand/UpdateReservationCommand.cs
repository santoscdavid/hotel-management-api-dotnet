using HotelManagement.Application.Common;
using MediatR;

namespace HotelManagement.Application.Commands.Reservation.UpdateReservationCommand;

public sealed record UpdateReservationCommand(
    Guid Id,
    Guid RoomId,
    Guid GuestId,
    DateTime CheckIn,
    DateTime CheckOut,
    decimal TotalPrice
) : IRequest<Result<Guid>>;