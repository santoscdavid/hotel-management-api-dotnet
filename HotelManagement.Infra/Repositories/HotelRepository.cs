using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Repositories;
using HotelManagement.Infra.Context;
using HotelManagement.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infra.Repositories
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(HotelDbContext context) : base(context) { }

        public async Task<Hotel?> GetWithRoomsAsync(Guid hotelId)
        {
            return await _dbSet
                .Include(h => h.Rooms)
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.Id == hotelId);
        }

        public async Task<Hotel?> GetWithEmployeesAsync(Guid hotelId)
        {
            return await _dbSet
                .Include(h => h.Employees)
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.Id == hotelId);
        }

        public async Task<Hotel?> GetWithRoomsAndEmployeesAsync(Guid hotelId)
        {
            return await _dbSet
                .Include(h => h.Rooms)
                .Include(h => h.Employees)
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.Id == hotelId);
        }

        public async Task<IEnumerable<Hotel>> GetHotelsWithAvailableRoomsAsync(DateTime checkIn, DateTime checkOut)
        {
            return await _dbSet
                .Include(h => h.Rooms)
                .Where(h => h.Rooms.Any(r => r.IsAvailable))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
