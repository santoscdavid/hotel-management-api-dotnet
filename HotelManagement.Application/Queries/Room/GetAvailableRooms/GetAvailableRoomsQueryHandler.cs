using HotelManagement.Application.Dtos.Room;
using HotelManagement.Domain.Repositories;
using MediatR;

namespace HotelManagement.Application.Queries.Room.GetAvailableRooms
{
    public sealed class GetAvailableRoomsQueryHandler : IRequestHandler<GetAvailableRoomsQuery, IEnumerable<RoomDto>>
    {
        private readonly IRoomRepository _repository;

        public GetAvailableRoomsQueryHandler(IRoomRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<RoomDto>> Handle(GetAvailableRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _repository.GetAvailableRoomsAsync(request.HotelId, cancellationToken);

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
