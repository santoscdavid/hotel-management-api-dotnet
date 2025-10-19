namespace HotelManagement.API.DTOs.Request.Reservation;

public class UpdateReservationRequest
{
    public Guid RoomId { get; init; }
    public Guid GuestId { get; init; }
    public DateTime CheckIn { get; init; }
    public DateTime CheckOut { get; init; }
    public decimal TotalPrice { get; init; }
}