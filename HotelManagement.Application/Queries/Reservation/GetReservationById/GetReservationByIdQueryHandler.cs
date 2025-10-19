using HotelManagement.Application.Dtos.Reservations;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Queries.Reservation.GetReservationById;

public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationDto?>
{
    private readonly IReservationRepository _reservationRepository;

    public GetReservationByIdQueryHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<ReservationDto?> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(request.Id, cancellationToken);

        if (reservation is null)
            return null;

        return new ReservationDto
        {
            Id = reservation.Id,
            RoomId = reservation.RoomId,
            GuestId = reservation.GuestId,
            CheckInDate = reservation.CheckIn,
            CheckOutDate = reservation.CheckOut,
            Status = reservation.Status,
            TotalPrice = reservation.TotalPrice,
            CreatedAt = reservation.CreatedAt,
        };
    }
}