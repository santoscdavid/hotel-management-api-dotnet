using FluentValidation;

namespace HotelManagement.Application.Commands.Room.DeleteRoomCommand
{
    public class DeleteRoomCommandValidator : AbstractValidator<Room.DeleteRoomCommand.DeleteRoomCommand>
    {
        public DeleteRoomCommandValidator()
        {
            RuleFor(x => x.RoomId)
                .NotEmpty().WithMessage("O identificador do quarto é obrigatório.");
        }
    }
}
