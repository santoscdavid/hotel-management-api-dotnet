using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Repositories.Base;

namespace HotelManagement.Domain.Repositories
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetByGuestIdAsync(Guid guestId);
        Task<IEnumerable<Reservation>> GetByRoomIdAsync(Guid roomId);
        Task<IEnumerable<Reservation>> GetUpcomingReservationsAsync();
        Task<IEnumerable<Reservation>> GetReservationsBetweenDatesAsync(DateTime start, DateTime end);
        Task<bool> IsRoomAvailableAsync(Guid roomId, DateTime checkIn, DateTime checkOut);
    }

}
