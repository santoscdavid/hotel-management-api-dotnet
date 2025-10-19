namespace HotelManagement.API.DTOs.Request.Room;

public class CreateRoomRequest
{
    public Guid HotelId { get; init; }
    public int Number { get; init; }
    public string Type { get; init; } = null!;
    public decimal PricePerNight { get; init; }
}