namespace HotelManagement.API.DTOs.Request.Hotel;

public class UpdateHotelRequest
{
    public string? Name { get; init; }
    public string? Address { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Email { get; init; }
}