using HotelManagement.Domain.Enums;

namespace HotelManagement.Application.Dtos.Reservations
{
    public class ReservationDto
    {
        public Guid Id { get; init; }
        public Guid GuestId { get; init; }
        public Guid RoomId { get; init; }
        public DateTime CheckInDate { get; init; }
        public DateTime CheckOutDate { get; init; }
        public decimal TotalPrice { get; init; }
        public ReservationStatusType Status { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
    }
}
