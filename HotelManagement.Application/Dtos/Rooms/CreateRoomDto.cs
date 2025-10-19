namespace HotelManagement.Application.Dtos.Room
{
    public class CreateRoomDto
    {
        public string Number { get; init; } = string.Empty;
        public string Type { get; init; } = string.Empty;
        public decimal PricePerNight { get; init; }
        public string? Description { get; init; }
        public Guid HotelId { get; init; }
    }
}
