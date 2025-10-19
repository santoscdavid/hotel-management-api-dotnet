namespace HotelManagement.Application.Dtos.Guests
{
    public class GuestDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string PhoneNumber { get; init; } = string.Empty;
        public string DocumentNumber { get; init; } = string.Empty; // CPF, RG, etc
        public DateTime CreatedAt { get; init; }
    }
}
