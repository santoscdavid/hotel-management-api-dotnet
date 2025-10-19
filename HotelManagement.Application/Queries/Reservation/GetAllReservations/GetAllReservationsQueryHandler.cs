using HotelManagement.Application.Dtos.Reservations;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Queries.Reservation.GetAllReservations;

public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, IEnumerable<ReservationDto>>
{
    private readonly IReservationRepository _reservationRepository;

    public GetAllReservationsQueryHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<IEnumerable<ReservationDto>> Handle(GetAllReservationsQuery request,
        CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.GetAllAsync(cancellationToken);

        return reservations.Select(res => new ReservationDto
            {
                Id = res.Id,
                RoomId = res.RoomId,
                GuestId = res.GuestId,
                CheckInDate = res.CheckIn,
                CheckOutDate = res.CheckOut,
                Status = res.Status,
                TotalPrice = res.TotalPrice,
                CreatedAt = res.CreatedAt,
            }
        );
    }
}