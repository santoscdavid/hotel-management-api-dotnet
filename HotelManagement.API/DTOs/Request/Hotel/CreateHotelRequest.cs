namespace HotelManagement.API.DTOs.Request.Hotel;

public class CreateHotelRequest
{
    public string Name { get; init; } = null!;
    public string Address { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string Email { get; init; } = null!;
}