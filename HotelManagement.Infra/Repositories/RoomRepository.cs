using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Repositories;
using HotelManagement.Infra.Context;
using HotelManagement.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infra.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelDbContext context) : base(context) { }

        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(Guid hotelId, CancellationToken cancellationToken)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(r => r.IsAvailable && r.HotelId == hotelId)
                .ToListAsync(cancellationToken);
        }
    }
}
