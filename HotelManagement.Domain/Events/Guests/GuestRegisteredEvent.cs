using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Guest
{
    public sealed class GuestRegisteredEvent : IDomainEvent
    {
        public Guid GuestId { get; }
        public string FullName { get; } = null!;
        public string Email { get; } = null!;

        public GuestRegisteredEvent(Guid guestId, string fullName, string email)
        {
            GuestId = guestId;
            FullName = fullName;
            Email = email;
        }
    }
}
