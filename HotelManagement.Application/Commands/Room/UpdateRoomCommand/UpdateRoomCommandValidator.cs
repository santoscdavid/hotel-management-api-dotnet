using FluentValidation;

namespace HotelManagement.Application.Commands.Room.UpdateRoomCommand
{
    public sealed class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator()
        {
            RuleFor(x => x.HotelId)
                .NotEmpty().WithMessage("O identificador do hotel é obrigatório.");

            RuleFor(x => x.RoomId)
                .NotEmpty().WithMessage("O ID do quarto é obrigatório.");

            RuleFor(x => x.Number)
                .GreaterThan(10).WithMessage("O número do quarto deve ter até 10 caracteres.");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Tipo de quarto inválido.");

            RuleFor(x => x.PricePerNight)
                .GreaterThan(0).WithMessage("O preço por noite deve ser maior que zero.");
        }
    }
}