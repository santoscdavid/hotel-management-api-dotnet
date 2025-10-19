using HotelManagement.API.DTOs.Response.Reservation;

namespace HotelManagement.API.DTOs.Response.Guest;

public class GuestResponse
{
    public Guid Id { get; init; }
    public string FullName { get; init; } = null!;
    public string DocumentNumber { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public DateTime DateOfBirth { get; init; }
    public DateTime CreatedAt { get; init; }

    public IEnumerable<ReservationSummaryResponse>? Reservations { get; init; }
}