using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Enums;
using HotelManagement.Domain.Repositories.Base;

namespace HotelManagement.Domain.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee?> GetByEmailAsync(string email);
        Task<IEnumerable<Employee>> GetByHotelIdAsync(Guid hotelId);
        Task<IEnumerable<Employee>> GetByRoleAsync(RoleType role);
        Task<bool> ExistsByEmailAsync(string email);
    }
}
