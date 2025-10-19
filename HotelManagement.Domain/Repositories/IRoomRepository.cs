using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Repositories.Base;

namespace HotelManagement.Domain.Repositories
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        Task<IEnumerable<Room>> GetAvailableRoomsAsync(Guid hotelId, CancellationToken cancellationToken);
    }
}
