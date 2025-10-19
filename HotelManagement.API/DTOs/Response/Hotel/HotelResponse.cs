using HotelManagement.API.DTOs.Response.Room;

namespace HotelManagement.API.DTOs.Response.Hotel;

public class HotelResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string Address { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string Email { get; init; } = null!;
    public DateTime CreatedAt { get; init; }

    public IEnumerable<RoomSummaryResponse>? Rooms { get; init; }
    // public IEnumerable<EmployeeSummaryResponse>? Employees { get; init; }
}