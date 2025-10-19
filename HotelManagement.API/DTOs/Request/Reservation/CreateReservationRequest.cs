namespace HotelManagement.API.DTOs.Request.Reservation;

public class CreateReservationRequest
{
    public Guid GuestId { get; init; }
    public Guid RoomId { get; init; }
    public DateTime CheckIn { get; init; }
    public DateTime CheckOut { get; init; }
    public decimal TotalPrice { get; init; }
}