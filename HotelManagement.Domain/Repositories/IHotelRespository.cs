using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Repositories.Base;

namespace HotelManagement.Domain.Repositories
{
    public interface IHotelRepository : IBaseRepository<Hotel>
    {
        Task<Hotel?> GetWithRoomsAsync(Guid hotelId);
        Task<Hotel?> GetWithEmployeesAsync(Guid hotelId);
        Task<Hotel?> GetWithRoomsAndEmployeesAsync(Guid hotelId);
        Task<IEnumerable<Hotel>> GetHotelsWithAvailableRoomsAsync(DateTime checkIn, DateTime checkOut);
    }
}
