using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Repositories;
using HotelManagement.Infra.Context;
using HotelManagement.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infra.Repositories
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(HotelDbContext context) : base(context) { }

        public async Task<Admin?> GetByUsernameAsync(string username)
        {
            return await _dbSet
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(a => a.Username == username);
        }
    }
}
