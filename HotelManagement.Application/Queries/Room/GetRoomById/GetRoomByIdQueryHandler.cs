using HotelManagement.Application.Dtos.Room;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Queries.Room.GetRoomById
{
    public sealed class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomDto?>
    {
        private readonly IRoomRepository _repository;

        public GetRoomByIdQueryHandler(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<RoomDto?> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await _repository.GetByIdAsync(request.RoomId, cancellationToken);

            if (room == null)
                return null;

            return new RoomDto
            {
                Id = room.Id,
                Number = room.Number,
                Type = room.RoomType.ToString(),
                PricePerNight = room.PricePerNight,
                IsAvailable = room.IsAvailable,
                HotelId = room.HotelId
            };
        }
    }
}
