using FluentValidation;

namespace HotelManagement.Application.Commands.Guest.DeleteGuestCommand;

public class DeleteGuestCommandValidator : AbstractValidator<DeleteGuestCommand>
{
    public DeleteGuestCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O ID do hóspede é obrigatório para exclusão.");
    }
}