using HotelManagement.Domain.Enums;

namespace HotelManagement.API.DTOs.Request.Room;

public class UpdateRoomRequest
{
    public int? Number { get; init; }
    public Guid HotelId { get; init; }
    public string? Type { get; init; }
    public decimal? PricePerNight { get; init; }
    public bool? IsAvailable { get; init; }
}