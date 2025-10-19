using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Repositories;
using HotelManagement.Infra.Context;
using HotelManagement.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infra.Repositories
{
    public class GuestRepository : BaseRepository<Guest>, IGuestRepository
    {
        public GuestRepository(HotelDbContext context) : base(context) { }

        public async Task<Guest?> GetByEmailAsync(string email) =>
             await _dbSet.FirstOrDefaultAsync(g => g.Email == email);

        public async Task<Guest?> GetByDocumentAsync(string documentNumber) =>
            await _dbSet.FirstOrDefaultAsync(g => g.DocumentNumber == documentNumber);

        public async Task<bool> ExistsByEmailAsync(string email) =>
            await _dbSet.AnyAsync(g => g.Email == email);

        public async Task<IEnumerable<Guest>> SearchByNameAsync(string name) =>
            await _dbSet
                .Where(g => EF.Functions.Like(g.FullName, $"%{name}%"))
                .ToListAsync();

        public async Task<IEnumerable<Guest>> GetRecentGuestsAsync(int days)
        {
            var dateLimit = DateTime.UtcNow.AddDays(-days);
            return await _dbSet.Where(g => g.CreatedAt >= dateLimit).ToListAsync();
        }
    }
}
