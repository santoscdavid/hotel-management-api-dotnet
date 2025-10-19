using HotelManagement.API.DTOs.Response.Hotel;

namespace HotelManagement.API.DTOs.Response.Room;

public class RoomResponse
{
    public Guid Id { get; init; }
    public Guid HotelId { get; init; }
    public string Number { get; init; } = null!;
    public string Type { get; init; } = null!;
    public decimal PricePerNight { get; init; }
    public bool IsAvailable { get; init; }
    public DateTime CreatedAt { get; init; }

    public HotelSummaryResponse? Hotel { get; init; }
}