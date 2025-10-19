using FluentValidation;

namespace HotelManagement.Application.Commands.Reservation.DeleteReservationCommand;

public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
{
    public DeleteReservationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O ID da reserva é obrigatório para exclusão.");
    }
}