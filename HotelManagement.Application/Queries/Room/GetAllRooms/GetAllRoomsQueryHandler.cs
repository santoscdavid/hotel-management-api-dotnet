using HotelManagement.Application.Dtos.Room;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Queries.Room.GetAllRooms
{
    public sealed class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, IEnumerable<RoomDto>>
    {
        private readonly IRoomRepository _repository;

        public GetAllRoomsQueryHandler(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RoomDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _repository.GetAllAsync(cancellationToken);

            return rooms.Select(room => new RoomDto
            {
                Id = room.Id,
                Number = room.Number,
                Type = room.RoomType.ToString(),
                PricePerNight = room.PricePerNight,
                IsAvailable = room.IsAvailable,
                HotelId = room.HotelId
            });
        }
    }
}
