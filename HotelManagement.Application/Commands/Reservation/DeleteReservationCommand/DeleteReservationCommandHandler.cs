using HotelManagement.Application.Common;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Commands.Reservation.DeleteReservationCommand;

public sealed class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Result<Guid>>
{
    private readonly IReservationRepository _reservationRepository;

    public DeleteReservationCommandHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<Result<Guid>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(request.Id, cancellationToken);

        if (reservation is null)
            return Result<Guid>.Failure("Reserva não encontrada.");

        _reservationRepository.Delete(reservation);
        await _reservationRepository.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}