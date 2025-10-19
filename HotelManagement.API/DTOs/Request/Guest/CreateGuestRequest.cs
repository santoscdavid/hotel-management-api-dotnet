namespace HotelManagement.API.DTOs.Request.Guest;

public class CreateGuestRequest
{
    public string FullName { get; init; } = null!;
    public string DocumentNumber { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public DateTime DateOfBirth { get; init; }
}