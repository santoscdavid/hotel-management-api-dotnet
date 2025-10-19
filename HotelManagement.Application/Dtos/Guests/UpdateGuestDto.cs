namespace HotelManagement.Application.Dtos.Guests
{
    public class UpdateGuestDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? DocumentNumber { get; init; }
    }
}
