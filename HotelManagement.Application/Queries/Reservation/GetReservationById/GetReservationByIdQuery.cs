using HotelManagement.Application.Common;
using HotelManagement.Application.Dtos.Reservations;
using MediatR;

namespace HotelManagement.Application.Queries.Reservation.GetReservationById;

public sealed record GetReservationByIdQuery(Guid Id) : IRequest<ReservationDto?>;