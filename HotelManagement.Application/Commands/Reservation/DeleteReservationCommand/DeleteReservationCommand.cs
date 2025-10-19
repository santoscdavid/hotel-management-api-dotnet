using HotelManagement.Application.Common;
using MediatR;

namespace HotelManagement.Application.Commands.Reservation.DeleteReservationCommand;

public sealed record DeleteReservationCommand(Guid Id) : IRequest<Result<Guid>>;