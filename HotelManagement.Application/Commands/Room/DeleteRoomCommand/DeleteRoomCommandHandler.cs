using HotelManagement.Application.Common;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Commands.Room.DeleteRoomCommand
{
    internal class DeleteRoomCommandHandler : IRequestHandler<Room.DeleteRoomCommand.DeleteRoomCommand, Result>
    {
        private readonly IRoomRepository _repository;

        public DeleteRoomCommandHandler(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(Room.DeleteRoomCommand.DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _repository.GetByIdAsync(request.RoomId, cancellationToken);

            if (room is null)
                return Result.Failure("Quarto não encontrado");

            _repository.Delete(room);

            await _repository.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
