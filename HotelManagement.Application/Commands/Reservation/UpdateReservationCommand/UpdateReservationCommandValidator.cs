using FluentValidation;

namespace HotelManagement.Application.Commands.Reservation.UpdateReservationCommand;

public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
{
    public UpdateReservationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O ID da reserva é obrigatório.");

        RuleFor(x => x.RoomId)
            .NotEmpty()
            .WithMessage("O ID do quarto é obrigatório.");

        RuleFor(x => x.GuestId)
            .NotEmpty()
            .WithMessage("O ID do hóspede é obrigatório.");

        RuleFor(x => x.CheckIn)
            .NotEmpty()
            .WithMessage("A data de check-in é obrigatória.")
            .LessThan(x => x.CheckOut)
            .WithMessage("A data de check-in deve ser anterior à data de check-out.");

        RuleFor(x => x.CheckOut)
            .NotEmpty()
            .WithMessage("A data de check-out é obrigatória.")
            .GreaterThan(x => x.CheckIn)
            .WithMessage("A data de check-out deve ser posterior à data de check-in.");

        RuleFor(x => x.TotalPrice)
            .GreaterThan(0)
            .WithMessage("O valor total deve ser maior que zero.");
    }
}