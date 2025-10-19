using HotelManagement.Application.Common;
using HotelManagement.Domain.Enums;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Commands.Room.UpdateRoomCommand
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Result>
    {
        private readonly IRoomRepository _repository;

        public UpdateRoomCommandHandler(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _repository.GetByIdAsync(request.RoomId, cancellationToken);

            if (room is null)
                return Result.Failure("Quarto não encontrado");

            room.UpdateDetails(
                request.Number,
                request.Type != null ? Enum.Parse<RoomType>(request.Type) : null,
                request.PricePerNight);

            _repository.Update(room);
            await _repository.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}