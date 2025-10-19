using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Repositories.Base;

namespace HotelManagement.Domain.Repositories
{
    public interface IGuestRepository : IBaseRepository<Guest>
    {
        Task<Guest?> GetByEmailAsync(string email);
        Task<Guest?> GetByDocumentAsync(string documentNumber);
        Task<bool> ExistsByEmailAsync(string email);
        Task<IEnumerable<Guest>> SearchByNameAsync(string name);
        Task<IEnumerable<Guest>> GetRecentGuestsAsync(int days);
    }
}
