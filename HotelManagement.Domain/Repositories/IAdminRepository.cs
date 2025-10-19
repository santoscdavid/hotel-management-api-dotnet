using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Repositories.Base;

namespace HotelManagement.Domain.Repositories
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        Task<Admin?> GetByUsernameAsync(string username);
    }
}
