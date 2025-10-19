using HotelManagement.Application.Common;
using HotelManagement.Domain.Enums;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Commands.Room.CreateRoomCommand
{
    public sealed class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Result<Guid>>
    {
        private readonly IRoomRepository _repository;

        public CreateRoomCommandHandler(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Domain.Entities.Room(
                number: request.Number,
                type: Enum.Parse<RoomType>(request.RoomType),
                pricePerNight: request.PricePerNight,
                hotelId: request.HotelId
            );

            await _repository.AddAsync(room, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(room.Id);
        }
    }
}