using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Enums;
using HotelManagement.Domain.Repositories;
using HotelManagement.Infra.Context;
using HotelManagement.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infra.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(HotelDbContext context) : base(context) { }

        public async Task<IEnumerable<Reservation>> GetByGuestIdAsync(Guid guestId)
        {
            return await _dbSet
                .Where(r => r.GuestId == guestId)
                .Include(r => r.Room)
                .Include(r => r.Guest)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetByRoomIdAsync(Guid roomId)
        {
            return await _dbSet
                .Where(r => r.RoomId == roomId)
                .Include(r => r.Room)
                .Include(r => r.Guest)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetUpcomingReservationsAsync()
        {
            var now = DateTime.UtcNow;
            return await _dbSet
                .Where(r => r.CheckIn >= now)
                .Include(r => r.Room)
                .Include(r => r.Guest)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsBetweenDatesAsync(DateTime start, DateTime end)
        {
            return await _dbSet
                .Where(r => r.CheckIn < end && r.CheckOut > start)
                .Include(r => r.Room)
                .Include(r => r.Guest)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> IsRoomAvailableAsync(Guid roomId, DateTime checkIn, DateTime checkOut)
        {
            return !await _dbSet
                .Where(r => r.RoomId == roomId && r.Status != ReservationStatusType.Cancelled)
                .AnyAsync(r => checkIn < r.CheckOut && checkOut > r.CheckIn);
        }
    }
}
