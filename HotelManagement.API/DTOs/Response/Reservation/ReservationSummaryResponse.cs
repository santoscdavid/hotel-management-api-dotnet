namespace HotelManagement.API.DTOs.Response.Reservation;

public class ReservationSummaryResponse
{
    public Guid Id { get; init; }
    public Guid RoomId { get; init; }
    public DateTime CheckIn { get; init; }
    public DateTime CheckOut { get; init; }
    public decimal TotalPrice { get; init; }
    public string Status { get; init; } = null!;
}