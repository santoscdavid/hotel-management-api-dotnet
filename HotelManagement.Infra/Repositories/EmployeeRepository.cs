using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Enums;
using HotelManagement.Domain.Repositories;
using HotelManagement.Infra.Context;
using HotelManagement.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infra.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HotelDbContext context) : base(context) { }

        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _dbSet
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Employee>> GetByHotelIdAsync(Guid hotelId)
        {
            return await _dbSet
                .Where(e => e.Id == hotelId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetByRoleAsync(RoleType role)
        {
            return await _dbSet
                .Where(e => e.Role == role)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _dbSet.AnyAsync(e => e.Email == email);
        }
    }
}
