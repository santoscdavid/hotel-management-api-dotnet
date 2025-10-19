using HotelManagement.Application.Common;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Commands.Reservation.CreateReservationCommand;

public sealed class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Result<Guid>>
{
    private readonly IReservationRepository _reservationRepository;

    public CreateReservationCommandHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<Result<Guid>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = new Domain.Entities.Reservation(
            request.GuestId,
            request.RoomId,
            request.CheckIn,
            request.CheckOut,
            request.TotalPrice
        );

        await _reservationRepository.AddAsync(reservation, cancellationToken);
        await _reservationRepository.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(reservation.Id);
    }
}