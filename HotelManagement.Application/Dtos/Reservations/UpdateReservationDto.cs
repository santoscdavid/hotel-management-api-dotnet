namespace HotelManagement.Application.Dtos.Reservations
{
    public class UpdateReservationDto
    {
        public Guid Id { get; init; }
        public DateTime? CheckInDate { get; init; }
        public DateTime? CheckOutDate { get; init; }
        public bool? IsConfirmed { get; init; }
        public decimal? TotalPrice { get; init; }
    }
}
