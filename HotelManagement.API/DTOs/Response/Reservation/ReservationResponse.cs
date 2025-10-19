using HotelManagement.API.DTOs.Response.Guest;
using HotelManagement.API.DTOs.Response.Room;

namespace HotelManagement.API.DTOs.Response.Reservation;

public class ReservationResponse
{
    public Guid Id { get; init; }
    public Guid GuestId { get; init; }
    public GuestSummaryResponse? Guest { get; init; }

    public Guid RoomId { get; init; }
    public RoomSummaryResponse? Room { get; init; }

    public DateTime CheckIn { get; init; }
    public DateTime CheckOut { get; init; }
    public decimal TotalPrice { get; init; }
    public string Status { get; init; } = null!;
    public DateTime CreatedAt { get; init; }
}