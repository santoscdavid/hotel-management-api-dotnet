namespace HotelManagement.API.DTOs.Request.Guest;

public class UpdateGuestRequest
{
    public string? FullName { get; init; }
    public string? DocumentNumber { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public DateTime? DateOfBirth { get; init; }
}