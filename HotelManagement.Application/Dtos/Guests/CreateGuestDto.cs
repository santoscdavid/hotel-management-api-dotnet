namespace HotelManagement.Application.Dtos.Guests
{
    public class CreateGuestDto
    {
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string PhoneNumber { get; init; } = string.Empty;
        public string DocumentNumber { get; init; } = string.Empty;
    }
}
