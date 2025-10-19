using HotelManagement.Application.Dtos.Reservations;
using MediatR;

namespace HotelManagement.Application.Queries.Reservation.GetAllReservations;

public sealed record GetAllReservationsQuery : IRequest<IEnumerable<ReservationDto>>;