namespace HotelManagement.Application.Dtos.Reservations
{
    public class CreateReservationDto
    {
        public Guid GuestId { get; init; }
        public Guid RoomId { get; init; }
        public DateTime CheckInDate { get; init; }
        public DateTime CheckOutDate { get; init; }
    }
}
