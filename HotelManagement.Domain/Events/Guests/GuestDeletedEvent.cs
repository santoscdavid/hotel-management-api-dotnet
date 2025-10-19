using HotelManagement.Domain.Events.Base;

namespace HotelManagement.Domain.Events.Guest
{
    public sealed class GuestDeletedEvent : IDomainEvent
    {
        public Guid GuestId { get; }

        public GuestDeletedEvent(Guid guestId)
        {
            GuestId = guestId;
        }
    }
}
