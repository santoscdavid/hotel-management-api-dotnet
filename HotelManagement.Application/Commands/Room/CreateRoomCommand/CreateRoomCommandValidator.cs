using FluentValidation;

namespace HotelManagement.Application.Commands.Room.CreateRoomCommand
{
    public sealed class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.HotelId)
                .NotEmpty().WithMessage("O identificador do hotel é obrigatório.");

            RuleFor(x => x.Number)
                .GreaterThan(0).WithMessage("O número do quarto deve ser maior que zero.");

            RuleFor(x => x.RoomType)
                .IsInEnum().WithMessage("O tipo de quarto informado é inválido.");

            RuleFor(x => x.PricePerNight)
                .GreaterThan(0).WithMessage("O preço por noite deve ser maior que zero.");
        }
    }
}
