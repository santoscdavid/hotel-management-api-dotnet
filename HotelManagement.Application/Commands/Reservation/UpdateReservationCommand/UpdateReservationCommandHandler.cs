using FluentValidation;
using HotelManagement.Application.Common;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Commands.Reservation.UpdateReservationCommand;

public sealed class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Result<Guid>>
{
    private readonly IReservationRepository _reservationRepository;

    public UpdateReservationCommandHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<Result<Guid>> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(request.Id, cancellationToken);

        if (reservation is null)
            return Result<Guid>.Failure("Reserva não encontrada.");

        reservation.Update(
            request.CheckIn,
            request.CheckOut,
            request.TotalPrice
        );

        _reservationRepository.Update(reservation);
        await _reservationRepository.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(reservation.Id);
    }
}