namespace HotelManagement.Application.Dtos.Room
{
    public class UpdateRoomDto
    {
        public Guid Id { get; init; }
        public string? Type { get; init; }
        public decimal? PricePerNight { get; init; }
        public bool? IsAvailable { get; init; }
        public string? Description { get; init; }
    }

}
