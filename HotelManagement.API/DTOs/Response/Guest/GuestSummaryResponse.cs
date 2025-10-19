namespace HotelManagement.API.DTOs.Response.Guest;

public class GuestSummaryResponse
{
    public Guid Id { get; init; }
    public string FullName { get; init; } = null!;
    public string Email { get; init; } = null!;
}