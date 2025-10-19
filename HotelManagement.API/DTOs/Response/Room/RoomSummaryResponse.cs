namespace HotelManagement.API.DTOs.Response.Room;

public class RoomSummaryResponse
{
    public Guid Id { get; init; }
    public string Number { get; init; } = null!;
    public string Type { get; init; } = null!;
    public bool IsAvailable { get; init; }
    public decimal PricePerNight { get; init; }
}