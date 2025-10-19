namespace HotelManagement.Application.Dtos.Room
{
    public class RoomDto
    {
        public Guid Id { get; init; }
        public int Number { get; init; }
        public string Type { get; init; } = string.Empty;
        public decimal PricePerNight { get; init; }
        public bool IsAvailable { get; init; }
        public string? Description { get; init; }
        public Guid HotelId { get; init; }
    }
}
