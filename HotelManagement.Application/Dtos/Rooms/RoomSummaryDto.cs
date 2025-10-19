namespace HotelManagement.Application.Dtos.Rooms
{
    public class RoomSummaryDto
    {
        public Guid Id { get; init; }
        public string Number { get; init; } = string.Empty;
        public bool IsAvailable { get; init; }
    }
}
