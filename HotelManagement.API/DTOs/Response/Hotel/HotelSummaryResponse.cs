namespace HotelManagement.API.DTOs.Response.Hotel;

public class HotelSummaryResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string Address { get; init; } = null!;
}